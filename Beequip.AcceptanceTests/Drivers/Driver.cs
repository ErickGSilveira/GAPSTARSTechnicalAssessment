using Beequip.AcceptanceTests.Support;
using Microsoft.Playwright;
using System.Text;

namespace Beequip.AcceptanceTests.Drivers;

public class Driver : IDisposable
{
    private readonly Task<IPage> _page;
    private IBrowser? _browser;
    private readonly string _baseUrl;
    private readonly string _wsEndpoint;
    private readonly string _localBrowser;
    private readonly bool _useContainer;
    public IPage Page => _page.Result;
    private IBrowserContext? _context;
    public readonly float TimeOutDefault;
    public readonly float TimeOutLong;
    private string _basicAuth;

    public Driver(BrowserConfigs browserConfig) 
    {
                _baseUrl = browserConfig.BaseUrl;
        _localBrowser = browserConfig.LocalBrowser;
        _useContainer = browserConfig.ContainerUse;
        _wsEndpoint = browserConfig.WsEndpoint;
        _page = InitializePlaywright();
        TimeOutDefault = browserConfig.TimeOut.Default;
        TimeOutLong = browserConfig.TimeOut.Long;
        _basicAuth = browserConfig.Login.Basic;
    }
    

    private async Task<IPage> InitializePlaywright()
    {
        var playwright = await Playwright.CreateAsync();

        if (_useContainer && !string.IsNullOrEmpty(_wsEndpoint))
        {
            switch (_localBrowser.ToLower())
            {
                case "chromium":
                    _browser = await playwright.Chromium.ConnectAsync(_wsEndpoint, new BrowserTypeConnectOptions { SlowMo = 100 });
                    break;
                case "webkit":
                    _browser = await playwright.Webkit.ConnectAsync(_wsEndpoint, new BrowserTypeConnectOptions { SlowMo = 100 });
                    break;
                case "firefox":
                    _browser = await playwright.Firefox.ConnectAsync(_wsEndpoint, new BrowserTypeConnectOptions { SlowMo = 100 });
                    break;
                default:
                    throw new ArgumentException(String.Format("Selected {0} it's not a valid option, pls try one of: chromium, webkit or firefox", _localBrowser), "_LocalBrowser");
                    break;

            }
        }
        else
        {

            switch (_localBrowser.ToLower())
            {
                case "chromium":
                    _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, SlowMo = 100 , Args = new List<string>{ "--start-maximized" }});
                    break;
                case "webkit":
                    _browser = await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
                    break;
                case "firefox":
                    _browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
                    break;
                default:
                    throw new ArgumentException(String.Format("Selected {0} it's not a valid option, pls try one of: chromium, webkit or firefox", _localBrowser), "_LocalBrowser");
                    break;

            }
        }
        
        _context = await _browser.NewContextAsync(new BrowserNewContextOptions
        {
            BaseURL = _baseUrl,
            ViewportSize = ViewportSize.NoViewport
        });
        await _context.SetExtraHTTPHeadersAsync(new Dictionary<string, string>
        {
            { "Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(_basicAuth)) },
            { "x-vercel-protection-bypass", " VreVj3DC9fVuVRcQzUoz3rtAgitcbX6M" }
        });
        _context.SetDefaultTimeout(TimeOutDefault);
        return await _context.NewPageAsync();   
    }


    public void Dispose()
    {
        _context?.CloseAsync();
        _browser?.CloseAsync();
        GC.SuppressFinalize(this);
    }
}