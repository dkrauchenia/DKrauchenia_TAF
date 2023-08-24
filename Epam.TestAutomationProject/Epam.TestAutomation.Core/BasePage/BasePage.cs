using Epam.TestAutomation.Core.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TestAutomation.Core.BasePage
{
    public abstract class BasePage
    {
        public abstract string Url { get; }

        public Button AcceptAllCookiesButton => new Button(By.XPath("//*[@id = 'onetrust-accept-btn-handler']"));

        public bool IsOpened()
        {
            return Browser.Browser.Instance.GetUrl().Equals(Url);
        }

        public void AcceptAllCookies()
        {
            AcceptAllCookiesButton.Click();
        }

        public IWebElement FindElement(By by)
        {
            return Browser.Browser.Instance.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return Browser.Browser.Instance.FindElements(by);
        }
    }
}
