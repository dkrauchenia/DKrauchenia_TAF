using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Elements;
using Epam.TestAutomation.Pages.Pages;
using OpenQA.Selenium.Interactions;


namespace Epam.TestAutomation.Tests
{
    [TestFixture]
    public class CareersPageTests : BaseTest
    {
        private CareersPage _careersPage;
        private JobListingsPage _jobListingsPage;
        private MainPage _mainPage;
        private Actions _actions;

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage();
            _careersPage = new CareersPage();
            _jobListingsPage = new JobListingsPage();
            _actions = new Actions(Browser.Instance.Driver);
            _mainPage.AcceptAllCookies();
        }

        [Test]
        public void VerifyListOfAvailableCountries()
        {
            var tabLinks = _jobListingsPage.TabLinks;

            List<string> expectedCountries = new() { "AMERICAS", "EMEA", "APAC" };

            _mainPage.Header.CareersLink.Click();
            _actions.MoveToElement(_careersPage.FindYourDreamJob.OriginalWebElement).Build().Perform();
            WebElementsExtension.ClickUsingJS(_careersPage.FindYourDreamJob);
            Browser.Instance.ScrollToElement(_jobListingsPage.OurLocations.OriginalWebElement);

            List<string> actualCountries = tabLinks.Select(a => a.GetText().Trim()).ToList();

            Assert.That(actualCountries, Is.EqualTo(expectedCountries), "Actual countries do not correspond to expected");
        }
    }
}
