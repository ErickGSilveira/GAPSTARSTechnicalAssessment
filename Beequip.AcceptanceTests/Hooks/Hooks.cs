using Beequip.AcceptanceTests.Drivers;
using Beequip.AcceptanceTests.Support;
using Reqnroll;
using Reqnroll.BoDi;

namespace Beequip.AcceptanceTests.Hooks
{
    [Binding]
    public sealed class Hooks(IObjectContainer container)
    {
        private readonly AppConfiguration _appConfiguration = AppConfigurationHelper.GetAppConfiguration();

        [BeforeScenario]
        public void BeforeScenario()
        {
            container.RegisterInstanceAs(_appConfiguration, nameof(AppConfiguration));
            var driver = new Lazy<Driver>(() => new Driver(_appConfiguration.BrowserConfigs));
            container.RegisterInstanceAs(driver, nameof(Driver));
        }

    }
}