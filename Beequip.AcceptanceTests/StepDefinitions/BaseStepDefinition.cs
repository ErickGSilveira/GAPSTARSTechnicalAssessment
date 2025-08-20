using Beequip.AcceptanceTests.Drivers;
using Beequip.AcceptanceTests.Pages;
using Microsoft.Playwright.NUnit;
using Reqnroll.BoDi;

namespace Beequip.AcceptanceTests.StepDefinitions
{
    public class BaseStepDefinition : PageTest
    {
        protected readonly ScenarioContext ScenarioContext;
        protected readonly Lazy<Driver> Driver;
        protected HomePage HomePage;
        protected MarketPlaceHomePage MarketPlaceHome;
        protected EquipmentListPage EquipmentList;
        protected EquipmentDetailPage EquipmentDetail;
        protected CompanySelectionPage CompanySelection;
        protected MonthlyPaymentPage MonthlyPaymentPage;

        public BaseStepDefinition(ObjectContainer container, ScenarioContext scenarioContext)
        {
            ScenarioContext = scenarioContext;
            Driver = container.Resolve<Lazy<Driver>>(nameof(Drivers.Driver));
            HomePage = new HomePage(Driver.Value.Page);
            MarketPlaceHome = new MarketPlaceHomePage(Driver.Value.Page);
            EquipmentList = new EquipmentListPage(Driver.Value.Page);
            EquipmentDetail = new EquipmentDetailPage(Driver.Value.Page);
            CompanySelection = new CompanySelectionPage(Driver.Value.Page);
            MonthlyPaymentPage = new MonthlyPaymentPage(Driver.Value.Page);
        }

    }
}
