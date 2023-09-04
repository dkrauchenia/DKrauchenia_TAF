using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Helpers;
using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Utilities.Logger;

namespace Epam.TestAutomation.Tests
{
    public abstract class BaseTest
    {
        public TestContext TestContext { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Logger.InitLogger(TestContext.CurrentContext.Test.Name, TestContext.CurrentContext.TestDirectory);

        }

        [SetUp]
        public virtual void BeforeTest()
        {
            Logger.Info("Test started to run");
            Browser.Instance.GoToUrl(TestSettings.ApplicationUrl);
            Waiters.WaitForPageLoad();

        }

        [TearDown]
        public virtual void CleanTest()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                Logger.Info("Test is failed");
            }
            Logger.Info("Test is completed");
            Browser.Instance.Quit();
        }
    }
}
