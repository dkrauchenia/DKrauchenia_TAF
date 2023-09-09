using Epam.TestAutomation.Core.Helpers;
using Epam.TestAutomation.Utilities.Logger;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace Epam.TestAutomation.Core.Browser
{
    public class Browser
    {
        private static ThreadLocal<Browser> _browser;
        protected internal IWebDriver _driver { get; set; }
        public IWebDriver Driver => _driver;
        public string Url
        {
            get => _driver.Url;
            set => _driver.Url = value;
        }
        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }

        static Browser()
        {
            _browser = new ThreadLocal<Browser>(() => new Browser(DriverFactory.GetWebDriver(TestSettings.Browser)));
        }

        public static Browser Instance
        {
            get
            {
                _browser.Value = _browser.Value != null
                    ? _browser.Value
                    : new Browser(DriverFactory.GetWebDriver(TestSettings.Browser));
                return _browser.Value;
            }
        }

        public void Maximize()
        {
            Logger.Info("Maximize Browser");
            _driver.Manage().Window.Maximize();
        }

        public string GetUrl()
        {
            return _driver.Url;
        }

        public void GoToUrl(string url)
        {
            Logger.Info($"Open url: {url}");
            _driver.Navigate().GoToUrl(url);
        }

        public void Refresh()
        {
            Logger.Info("Refresh page");
            _driver.Navigate().Refresh();
        }

        public void Back()
        {
            Logger.Info("Navigate Back");
            _driver.Navigate().Back();
        }
        
        public void ScrollTop()
        {
            Logger.Info("Scroll page top");
            ExecuteScript("$(window).scrollTop(0)");
        }

        public void ScrollToElement(IWebElement element)
        {
            ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void ScrollToBottom()
        {
            ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }

        public IWebElement FindElement(By locator)
        {
            return _driver.FindElement(locator);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return _driver.FindElements(by);
        }

        public void SetSessionToken(string token)
        {
            var tokenValue = "{\"type\":\"bearer\",\"value\":\"" + token + " \"}";
            ExecuteScript("javascript:localStorage.token=arguments[0];", tokenValue);
        }

        public void Close()
        {
            Logger.Info("Close current page");
            _driver.Close();
        }

        public void Quit()
        {
            Logger.Info("Quit Browser");
            try
            {
                _driver.Quit();
            }

            catch (Exception ex)
            {
                Logger.Info($"Unable to Quit the browser. Reason: {ex.Message}");
            }
        }

        public object ExecuteScript(string script, params object[] args)
        {
            try
            {
                return ((IJavaScriptExecutor)_driver).ExecuteScript(script, args);
            }
            catch (WebDriverTimeoutException e)
            {
                Logger.Info($"Error: Timeout Exception thrown while running JS Script:{e.Message}-{e.StackTrace}");
            }
            return null;
        }

        public WebDriverWait Waiters() => new(_driver, TestSettings.WebDriverTimeOut);

        public Actions Action => new Actions(_driver);

 
    }
}