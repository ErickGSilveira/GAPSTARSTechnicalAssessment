namespace Beequip.AcceptanceTests.Support;

public class AppConfiguration
{
    public BrowserConfigs BrowserConfigs { get; set; }
}

public class BrowserConfigs
{
    public string LocalBrowser { get; set; }
    public bool ContainerUse { get; set; }
    public string WsEndpoint { get; set; }
    public TimeOut TimeOut { get; set; }
    public Login Login { get; set; }
}

public class TimeOut
{
    public int Default { get; set; }
    public int Long { get; set; }
}

public class Login
{
    public string Basic { get; set; }
    public string Bypass { get; set; }
}
