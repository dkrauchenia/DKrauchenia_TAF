using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Pages.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TestAutomation.Tests
{
    [TestFixture]
    public class SearchPageTests : BaseTest
    {
        private MainPage _mainPage;
        private SearchResultsPage _searchResultsPage;

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage();
            _searchResultsPage = new SearchResultsPage();
            _mainPage.AcceptAllCookies();
        }

        [Test]
        [TestCase ("Automation", 5)]
        public void VerifyThatSearchResultsContainKeyWord(string keyWord, int resultsAmount)
        {
            _mainPage.Header.SearchButton.Click();
            _mainPage.Header.SearchForm.SendKeys(keyWord);
            _mainPage.Header.FindButton.Click();

            Waiters.WaitForPageLoad();

            bool searchResultsContainKeyWord = _searchResultsPage.SearchResultsList.GetElements()
                .Take(resultsAmount)
                .All(a => a.GetText().ToLower().Contains(keyWord.ToLower()));

            Assert.IsTrue(searchResultsContainKeyWord, "Not all of the search results contain the key word");
        }
    }
}
