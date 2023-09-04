using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.Pages
{
    public class SearchResultsPage : BasePage
    {
        public override string Url => "https://www.epam.com/search";

        public ElementsList<BaseElement> SearchResultsList => new ElementsList<BaseElement>(By.XPath("//div[@class = 'search-results__items']"));


    }
}
