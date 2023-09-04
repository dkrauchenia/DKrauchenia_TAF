using Epam.TestAutomation.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.Panels
{
    public class Header : BasePanel
    {
        public Button SearchButton => new Button(By.XPath("//span[contains(@class,'dark-iconheader-search__search-icon')]"));

        public TextInput SearchForm => new TextInput(By.XPath("//*[@id='new_form_search']"));

        public Button FindButton => new Button(By.XPath("//*[@class='bth-text-layer']"));

        public Link CareersLink => new Link(By.XPath("//*[contains(@class,'item-link') and @href='/careers']"));

        public Button JoinOurTeam => new Button(By.XPath("//*[contains(@class,'top-navigation__main-link') and @href='/careers/job-listings']"));

        public Button LanguageSelector => new Button(By.XPath("//button[@class='location-selector__button']"));

        public Dropdown LanguageDropdown => new Dropdown(By.XPath("//*[@class='location-selector__panel']"));

        public ElementsList<BaseElement> ListOfLanguages => new ElementsList<BaseElement>(By.XPath("//*[@class='location-selector__item']"));

        public Header(By locator) : base(locator) { }
    }
}
