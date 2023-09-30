using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.Pages
{
    public class SearchResultsPage : BasePage
    {
        public override string Url => "https://www.epam.com/search";

        public ElementsList<BaseElement> SearchResultsList => new ElementsList<BaseElement>(By.XPath("//div[@class = 'search-results__items']"));

        public Link FirstSearchResult => new Link(By.XPath("//article[@class='search-results__item'][1]//a[@class='search-results__title-link']"));

        public HtmlElement ArticleHeader => new HtmlElement(By.XPath("//div[@class='header_and_download']"));

        public Button ViewMore => new Button(By.XPath("//*[@class='search - results__view - more - text']"));

    }
}
