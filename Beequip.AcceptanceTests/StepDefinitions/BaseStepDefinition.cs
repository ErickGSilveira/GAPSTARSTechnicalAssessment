using Beequip.AcceptanceTests.Drivers;
using Microsoft.Playwright.NUnit;
using Reqnroll.BoDi;

namespace Beequip.AcceptanceTests.StepDefinitions
{
    public class BaseStepDefinition : PageTest
    {
        protected readonly Lazy<Driver> Driver;

        public BaseStepDefinition(ObjectContainer container)
        {
            Driver = container.Resolve<Lazy<Driver>>(nameof(Drivers.Driver));
        }

    }
}
