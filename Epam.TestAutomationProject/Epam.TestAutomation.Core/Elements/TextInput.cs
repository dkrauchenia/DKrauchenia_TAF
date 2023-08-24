using OpenQA.Selenium;

namespace Epam.TestAutomation.Core.Elements
{
    public class TextInput : BaseElement
    {
        public TextInput(By element) : base(element)
        {
        }

        public TextInput(IWebElement element) : base(element)
        {

        }

    }
}
