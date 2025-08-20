using System.Text.Json;

namespace Beequip.AcceptanceTests.Support;

public static class AppConfigurationHelper
{
    public static AppConfiguration GetAppConfiguration()
    {
        string envFile;
        var envFilePath = "../../../appsettings.json";

        envFile = Environment.GetEnvironmentVariable("envFile");
        if (envFile != null)
        {
            envFilePath = "../../../" + envFile + ".appsettings.json";
        }
        using var r = new StreamReader(envFilePath);
        var jsonStr = r.ReadToEnd();
        return JsonSerializer.Deserialize<AppConfiguration>(jsonStr) ?? throw new InvalidOperationException();
    }

}