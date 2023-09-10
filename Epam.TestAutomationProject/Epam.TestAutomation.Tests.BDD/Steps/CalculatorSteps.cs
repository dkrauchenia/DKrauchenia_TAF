using Epam.TestAutomation.Tests.BDD.Utils;
using Epam.TestAutomation.Utilities;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Epam.TestAutomation.Tests.BDD.Steps
{
    [Binding]
    public class CalculatorSteps
    {
        private Calculator _calculator = new();

        [StepDefinition(@"I provide number (.*) into calculator")]
        public void GivenIProvideNumberIntoCalculator(double operand)
        {
            _calculator.EnterOperand(operand);
        }

        [When(@"I choose Sum operation")]
        public void WhenIChooseSumOperation()
        {
            _calculator.Sum();
        }

        [When(@"I choose Diff operation")]
        public void WhenIChooseDiffOperation()
        {
            _calculator.Diff();
        }

        [When(@"I choose Mult operation")]
        public void WhenIChooseMultOperation()
        {
            _calculator.Mult();
        }

        [When(@"I choose Div operation")]
        public void WhenIChooseDivOperation()
        {
            _calculator.Div();
        }

        [When(@"I choose '(Diff|Mult|Sum|Div)' operation")]
        public void WhenIChooseOperation(string command)
        {
            switch (command)
            {
                case "Diff":
                    WhenIChooseDiffOperation();
                    break;
                case "Mult":
                    WhenIChooseMultOperation();
                    break;
                case "Sum":
                    WhenIChooseSumOperation();
                    break;
                case "Div":
                    WhenIChooseDivOperation();
                    break;
            }
        }

        [Then(@"Result of calculation should be (.*)")]
        public void ThenResultOfCalculationShouldBe(double result)
        {
            Assert.That(_calculator.Result, Is.EqualTo(result), "Invalid calculation result!");
        }

        [Then(@"I remember the result of calculation")]
        public void ThenIRememberTheResultOfCalculation()
        {
            var contextVar = ContextVariables.CalculationResultsList;
            if (ContextVariableHelper.IsValueExist(contextVar))
            {
                ContextVariableHelper.GetValueFromContext<List<double>>(contextVar).Add(_calculator.Result);
            }
            else
            {
                ContextVariableHelper.SetValueToContext(contextVar, new List<double> {_calculator.Result});
            }
        }

        [Then(@"I check that collection of results contains (.*) items")]
        public void ThenICheckThatCollectionOfResultsContainsItems(int items)
        {
            var results = ContextVariableHelper.GetValueFromContext<List<double>>(ContextVariables.CalculationResultsList);
            Assert.That(results, Has.Count.EqualTo(items), "Invalid number of operations is present!");
        }

    }
}
