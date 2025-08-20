using Reqnroll.BoDi;

namespace Beequip.AcceptanceTests.StepDefinitions;

[Binding]
public class CalculatorStepDefinitions(ObjectContainer container) : BaseStepDefinition(container)
{

    [Given("the first number is {int}")]
    public async Task GivenTheFirstNumberIs(int number)
    {
        await Driver.Value.Page.GotoAsync("");
    }

    [Given("the second number is {int}")]
    public void GivenTheSecondNumberIs(int number)
    {
        //TODO: implement arrange (precondition) logic

        throw new PendingStepException();
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        //TODO: implement act (action) logic

        throw new PendingStepException();
    }

    [Then("the result should be {int}")]
    public void ThenTheResultShouldBe(int result)
    {
        //TODO: implement assert (verification) logic

        throw new PendingStepException();
    }
}