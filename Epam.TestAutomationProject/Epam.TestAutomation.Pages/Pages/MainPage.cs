using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.Helpers;
using Epam.TestAutomation.Pages.Panels;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.Pages
{
    public class MainPage : BasePage
    {
        public override string Url => TestSettings.ApplicationUrl;

        public Header Header => new Header(By.XPath("//*[@class = 'header__content']"));
    }
}
