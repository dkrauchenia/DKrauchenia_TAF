﻿using OpenQA.Selenium;

namespace Epam.TestAutomation.Core.Elements
{
    public class Button : BaseElement
    {
        public Button(By locator) : base(locator)
        {

        }

        public Button(IWebElement element) : base(element)
        {

        }
    }
}
