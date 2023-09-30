using Epam.TestAutomation.Core.Elements;
using Epam.TestAutomation.Core.Utils;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Epam.TestAutomation.Core.BasePage
{
    public abstract class BasePage
    {
        public abstract string Url { get; }

        public bool IsOpened()
        {
            return Browser.Browser.Instance.GetUrl().Equals(Url);
        }

        public IWebElement FindElement(By by)
        {
            return Browser.Browser.Instance.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return Browser.Browser.Instance.FindElements(by);
        }

        public Button AcceptAllCookiesButton => new Button(By.XPath("//*[@id = 'onetrust-accept-btn-handler']"));

        public void AcceptAllCookies()
        {
            Waiters.WaitForCondition(() => AcceptAllCookiesButton.IsDisplayed());
            AcceptAllCookiesButton.Click();
        }
    }
}
