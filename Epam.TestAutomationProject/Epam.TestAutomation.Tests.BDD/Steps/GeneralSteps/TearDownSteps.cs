using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Helpers;
using Epam.TestAutomation.Utilities.Logger;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Epam.TestAutomation.Tests.BDD.Steps.GeneralSteps
{
    [Binding]
    public class TearDownSteps
    {
        [AfterScenario(Order = 1)]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                Logger.Info($"Test '{TestContext.CurrentContext.Test.MethodName}' is passed.");
            }

            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                Logger.Info($"Test '{TestContext.CurrentContext.Test.MethodName}' is failed.");
            }

            Logger.Info($"'{TestContext.CurrentContext.Test.ClassName}' is finished.");
            Browser.Instance.Quit();
        }
    }
}
