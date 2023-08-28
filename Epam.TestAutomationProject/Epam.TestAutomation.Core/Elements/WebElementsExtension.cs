using OpenQA.Selenium.Interactions;

namespace Epam.TestAutomation.Core.Elements
{
    public static class WebElementsExtension
    {
        public static void ClickUsingJS(this BaseElement element)
        {
            Browser.Browser.Instance.ExecuteScript("arguments[0].click()", element.OriginalWebElement);
        }

        public static void DragAndDrop(this BaseElement element, BaseElement targetElement)
        {
            CreateAction().DragAndDrop(element.OriginalWebElement, targetElement.OriginalWebElement).Perform();
        }

        private static Actions CreateAction()
        {
            return Browser.Browser.Instance.Actions;
        }
    }
}
