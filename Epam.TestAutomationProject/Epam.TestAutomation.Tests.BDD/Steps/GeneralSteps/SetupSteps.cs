using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Utilities.Logger;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Epam.TestAutomation.Tests.BDD.Steps.GeneralSteps
{
    [Binding]
    public class SetupSteps
    {
        [BeforeFeature(Order = 1)]
        public static void SetUpLogger()
        {
            Logger.InitLogger(TestContext.CurrentContext.Test.Name, TestContext.CurrentContext.TestDirectory);

        }

        [BeforeScenario(Order = 1)]
        public static void Setup()
        {
            Logger.Info("Test begin");
            Browser.Instance.Maximize();
        }
    }
}
