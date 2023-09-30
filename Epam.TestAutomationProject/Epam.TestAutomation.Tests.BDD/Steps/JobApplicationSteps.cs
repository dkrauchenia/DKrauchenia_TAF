using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Elements;
using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Pages.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;

namespace Epam.TestAutomation.Tests.BDD.Steps
{
    [Binding]
    public class JobApplicationSteps
    {
        private MainPage _mainPage = new();
        private CareersPage _careersPage = new();
        private JobListingsPage _jobListingsPage = new();
        private ApplyNowPage _applyNowPage = new();
        private Actions _actions = new Actions(Browser.Instance.Driver);

        [Given(@"the user navigates to the main page")]
        public void GivenTheUserNavigatesToTheMainPage()
        {
            Browser.Instance.GoToUrl(_mainPage.Url);
            Waiters.WaitForPageLoad();
        }

        [Given(@"the user accepts all cookies")]
        public void GivenTheUserAcceptAllCookies()
        {
            _mainPage.AcceptAllCookies();
        }

        [When(@"the user clicks on the Careers link in the header")]
        public void WhenTheUserClicksOnTheCareersLinkInTheHeader()
        {
            _mainPage.Header.CareersLink.Click();
        }

        [When(@"the user clicks on the Find Your Dream Job link")]
        public void WhenTheUserClicksOnTheFindYourDreamJobLink()
        {
            _actions.MoveToElement(_careersPage.FindYourDreamJob.OriginalWebElement).Build().Perform();
            WebElementsExtension.ClickUsingJS(_careersPage.FindYourDreamJob);
        }

        [When(@"the user scrolls to the Our Locations section")]
        public void WhenTheUserScrollsToTheOurLocationsSection()
        {
            Browser.Instance.ScrollToElement(_jobListingsPage.OurLocations.OriginalWebElement);
        }

        [Then(@"the user should see the following list of available countries:")]
        public void ThenTheUserShouldSeeTheFollowingListOfAvailableCountries(Table table)
        {
            var expectedCountries = table.Rows.Select(row => row["Country"]).ToList();
            var tabLinks = _jobListingsPage.TabLinks;
            var actualCountries = tabLinks.Select(a => a.GetText().Trim()).ToList();

            Assert.That(actualCountries, Is.EqualTo(expectedCountries), "Actual countries do not correspond to expected");
        }

        [When(@"the user scrolls to the bottom of the page")]
        public void WhenTheUserScrollsToTheBottomOfThePage()
        {
            Browser.Instance.ScrollToBottom();
        }

        [When(@"the user clicks on the Register Your Interest Button")]
        public void WhenTheUserClicksOnTheRegisterYourInterestButton()
        {
            Browser.Instance.ScrollToElement(_jobListingsPage.RegisterYourInterest.OriginalWebElement);
            _jobListingsPage.RegisterYourInterest.Click();
        }

        [Then(@"the user should be redirected to the Job Application Page")]
        public void ThenTheUserShouldBeRedirectedToTheJobApplicationPage()
        {
            Assert.That(Browser.Instance.Url, Is.EqualTo(_applyNowPage.Url), "Incorrect page");
        }
    }
}
