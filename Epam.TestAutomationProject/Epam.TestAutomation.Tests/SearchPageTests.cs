using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Pages.Pages;

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

            Assert.That(searchResultsContainKeyWord, Is.True, "Not all of the search results contain the key word");
        }

        [Test]
        [TestCase ("Business Analysis")]
        public void VerifyThatArticleTitleContainsKeyWord(string keyWord)
        {
            _mainPage.Header.SearchButton.Click();
            _mainPage.Header.SearchForm.SendKeys(keyWord);
            _mainPage.Header.FindButton.Click();

            Waiters.WaitForPageLoad();

            var searchResultTitle = _searchResultsPage.FirstSearchResult.GetText().ToLower();

            _searchResultsPage.FirstSearchResult.Click();

            var articleTitle = _searchResultsPage.ArticleHeader.GetText().ToLower();

            Assert.That(searchResultTitle, Is.EqualTo(articleTitle), "Search result title doesn't match the article title!");
        }

        [Test]
        [TestCase ("20")]
        public void VerifyNumberOfArticlesDisplayedOnSearchResultsPage(string expectedResultsAmount)
        {
            _mainPage.Header.SearchButton.Click();
            _mainPage.Header.FrequentSearchQuery.Click();
            _mainPage.Header.FindButton.Click();

            Waiters.WaitForPageLoad();

            Browser.Instance.ScrollToBottom();
            Browser.Instance.ScrollToElement(_searchResultsPage.ViewMore.OriginalWebElement);

            var actualResultsAmount = _searchResultsPage.SearchResultsList.GetElements().Count.ToString();

            Assert.That(actualResultsAmount, Is.EqualTo(expectedResultsAmount), "Search results amount doesn't correspond to expected!");
        }


    }
}
