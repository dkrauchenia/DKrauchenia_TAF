using Epam.TestAutomation.Utilities.Logger;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Epam.TestAutomation.Core.Elements
{
    public abstract class BaseElement : IBaseElement
    {
        private readonly IWebElement _element;

        protected BaseElement(By locator)
        {
            _element = Browser.Browser.Instance.FindElement(locator);
        }

        protected BaseElement(IWebElement element)
        {
            _element = element;
        }

        public IWebElement OriginalWebElement => _element;

        public string GetText() => OriginalWebElement.Text.Trim();

        public string GetAttribute(string attributeName) => OriginalWebElement.GetAttribute(attributeName);


        public virtual void Click()
        {
            Logger.Info("Click on the element");
            OriginalWebElement.Click();
        }

        public void SendKeys(string text)
        {
            Logger.Info("Fill in the field");
            OriginalWebElement.SendKeys(text);
        }

        public void Clear()
        {
            Logger.Info("Clear the field");
            OriginalWebElement.Clear();
        }

        public bool Exists()
        {
            Logger.Info("Check if the element exists");
            return OriginalWebElement != null;
        }

        public bool IsDisplayed() => OriginalWebElement.Displayed;

        public bool IsEnabled() => OriginalWebElement.Enabled;

        public IWebElement FindElement(By by) => OriginalWebElement.FindElement(by);

        public ReadOnlyCollection<IWebElement> FindElements(By by) => OriginalWebElement.FindElements(by);
    }
}
