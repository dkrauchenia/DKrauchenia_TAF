using Epam.TestAutomation.Core.Enums;
using OpenQA.Selenium;
using System;
namespace Epam.TestAutomation.Core.Browser
{
    public static class DriverFactory
    {
        public static IWebDriver GetWebDriver(BrowserType browser)
        {
            IWebDriver createdWebDriver;
            switch (browser)
            {
                case BrowserType.Chrome:
                    createdWebDriver = new ChromeBrowser().CreateDriver();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browser));
            }
            return createdWebDriver;
        }
    }
}
