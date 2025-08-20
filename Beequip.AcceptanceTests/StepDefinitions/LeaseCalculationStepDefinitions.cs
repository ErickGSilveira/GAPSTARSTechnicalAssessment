using Beequip.AcceptanceTests.Pages;
using Beequip.AcceptanceTests.Support.DataTableHelper;
using Reqnroll;
using Reqnroll.BoDi;
using System;
using Beequip.AcceptanceTests.Support.Constants;
using Shouldly;

namespace Beequip.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class LeaseCalculationStepDefinitions(ObjectContainer container, ScenarioContext scenarioContext) : BaseStepDefinition(container, scenarioContext)
    {
        [Given("Im in the marketplace")]
        public async Task GivenImInTheMarketplace()
        {
            await HomePage.GoTo();
            await HomePage.NavigateToMarketPlaceAsync();
        }

        [Given("I have choose a equipment with the requirements")]
        public async Task GivenIHaveChooseAEquipmentWithTheRequirements(DataTable dataTable)
        {
            var equipmentLeaseRequest = dataTable.CreateInstance<EquipmentLeaseRequest>();
            await MarketPlaceHome.SelectSubcategory(equipmentLeaseRequest);
            await EquipmentList.Filter();
            ScenarioContext[LeaseConstants.EquipmentUrl] = Driver.Value.Page.Url;
        }

        [Given("I have {int} to use as down payment")]
        public void GivenIHaveToUseAsDownPayment(int downAmount)
        {
            ScenarioContext[LeaseConstants.DownPayment] = downAmount;
        }

        [Given("I want a lease duration to be {int} months")]
        public void GivenIWantALeaseDurationToBeIntMonths(int duration)
        {
            ScenarioContext[LeaseConstants.LeaseDuration] = duration;
        }


        [When("I request the quote of lease of the equipment")]
        public async Task WhenIRequestTheQuoteOfLeaseOfTheEquipment()
        {
            var faker = new Bogus.Faker();

            await EquipmentDetail.btnLease.ClickAsync();
            await Driver.Value.Page.WaitForLoadStateAsync();
            await CompanySelection.inputCompany.FillAsync("63204258");
            await CompanySelection.ìtemList.ClickAsync();
            await CompanySelection.inputEmail.FillAsync(faker.Internet.ExampleEmail());
            await CompanySelection.btnLease.ClickAsync();
            await Driver.Value.Page.WaitForLoadStateAsync();

            scenarioContext.TryGetValue(LeaseConstants.DownPayment, out int? downPayment);
            if (downPayment is not null)
            {
                await MonthlyPaymentPage.inputdownPayment.FillAsync(downPayment.ToString());
            }

            scenarioContext.TryGetValue(LeaseConstants.DownPayment, out int? leaseDuration);
            if (leaseDuration is not null)
            {
                await MonthlyPaymentPage.inputDuration.FillAsync(leaseDuration.ToString());
            }

            await MonthlyPaymentPage.btnPrimary.ClickAsync();
            await Driver.Value.Page.WaitForLoadStateAsync();

            await LeaseSendPage.inputName.FillAsync(faker.Name.FullName());
            await LeaseSendPage.inputBalloonPhone.FillAsync(faker.Phone.PhoneNumber("+## ### #######"));
            await LeaseSendPage.radioMorning.ClickAsync();
            await LeaseSendPage.btnPrimary.ClickAsync();
            await Driver.Value.Page.WaitForLoadStateAsync();
            await Task.Delay(20000);
        }


        [Then("I should be redirected to details page of the equipment")]
        public void ThenIShouldBeRedirectedToDetailsPageOfTheEquipment()
        {
            var expectedUrl = ScenarioContext[LeaseConstants.EquipmentUrl] as string;
            Driver.Value.Page.Url.ShouldBe(expectedUrl);
        }

    }
}
