using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Elements;
using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Pages.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Epam.TestAutomation.Tests
{
    [TestFixture]
    public class HeaderTests : BaseTest
    {
        private MainPage _mainPage;
        private JobListingsPage _jobListingsPage;
        private Actions _actions;

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage();
            _jobListingsPage = new JobListingsPage();
            _mainPage.AcceptAllCookies();
            _actions = new Actions(Browser.Instance.Driver);
        }

        [Test]
        public void VerifyThatjobListingsPageIsOpened()
        {
            var careersLink = _mainPage.Header.CareersLink.OriginalWebElement;
            var joinOurTeamLink = _mainPage.Header.JoinOurTeam.OriginalWebElement;

            _actions.MoveToElement(careersLink)
                  .MoveToElement(joinOurTeamLink)
                  .Click()
                  .Build()
                  .Perform();

            Assert.AreEqual(Browser.Instance.Url, _jobListingsPage.Url, "Incorrect page");
        }

        [Test]
        public void TestLocalizationDropdown()
        {
            var listOfLanguages = _mainPage.Header.ListOfLanguages;

            List<string> expectedLocalizations = new()
            {
                "Global (English)",
                "Hungary (English)",
                "СНГ (Русский)",
                "Česká Republika (Čeština)",
                "India (English)",
                "Україна (Українська)",
                "Czech Republic (English)",
                "日本 (日本語)",
                "中国 (中文)",
                "DACH (Deutsch)",
                "Polska (Polski)"
            };

            WebElementsExtension.ClickUsingJS(_mainPage.Header.LanguageSelector);         

            Waiters.WaitForCondition(() => _mainPage.Header.LanguageDropdown.IsDisplayed());

            var actualLocalizations = listOfLanguages.Select(a => a.GetText().Trim()).ToList();

            CollectionAssert.AreEqual(expectedLocalizations, actualLocalizations, "Actual localizations do not correspond to expected");

        }
    }
}
