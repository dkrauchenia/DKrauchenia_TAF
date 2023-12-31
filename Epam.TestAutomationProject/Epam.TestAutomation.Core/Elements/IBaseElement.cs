﻿namespace Epam.TestAutomation.Core.Elements
{
    public interface IBaseElement
    {
        string GetText();
        string GetAttribute(string attributeName);

        void Click();
        void SendKeys(string text);
        void Clear();

        bool IsDisplayed();
        bool IsEnabled();
    }
}
