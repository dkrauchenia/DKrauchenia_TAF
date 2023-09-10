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
    public class HeaderSteps
    {
        private MainPage _mainPage = new();
        private JobListingsPage _jobListingsPage = new();
        private Actions _actions = new Actions(Browser.Instance.Driver);
        private List<string> actualLocalizations = new List<string>();

        [Given(@"the user is on the main page")]
        public void GivenTheUserIsOnTheMainPage()
        {
            Browser.Instance.GoToUrl(_mainPage.Url);
            Waiters.WaitForPageLoad();
        }

        [Given(@"the user accepts cookies")]
        public void GivenTheUserAcceptCookies()
        {
            _mainPage.AcceptAllCookies();
        }

        [When(@"the user hovers over the Careers link")]
        public void WhenTheUserHoversOverTheCareersLink()
        {
            _actions.MoveToElement(_mainPage.Header.CareersLink.OriginalWebElement);
        }

        [When(@"the user clicks on the Join Our Team link")]
        public void WhenTheUserClicksOnTheJoinOurTeamLink()
        {
            _actions.MoveToElement(_mainPage.Header.JoinOurTeam.OriginalWebElement).Click().Build().Perform();
        }

        [Then(@"the user should be redirected to the Job Listings page")]
        public void ThenTheUserShouldBeRedirectedToTheJobListingsPage()
        {
            Assert.That(Browser.Instance.Url, Is.EqualTo(_jobListingsPage.Url), "Incorrect page");
        }

        [When(@"the user clicks on the language selector")]
        public void WhenTheUserClicksOnTheLanguageSelector()
        {
            WebElementsExtension.ClickUsingJS(_mainPage.Header.LanguageSelector);
            Waiters.WaitForCondition(() => _mainPage.Header.LanguageDropdown.IsDisplayed());
        }

        [Then(@"the user should see the following language options:")]
        public void ThenTheUserShouldSeeTheFollowingLanguageOptions(Table table)
        {
            var expectedLocalizations = table.Rows.Select(row => row["Language"]).ToList();
            var listOfLanguages = _mainPage.Header.ListOfLanguages;
            actualLocalizations = listOfLanguages.Select(a => a.GetText().Trim()).ToList();

            Assert.That(actualLocalizations, Is.EqualTo(expectedLocalizations), "Actual localizations do not correspond to expected");
        }



    }
}
