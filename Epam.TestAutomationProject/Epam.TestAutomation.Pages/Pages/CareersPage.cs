using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.Pages
{
    public class CareersPage : BasePage
    {
        public override string Url => "https://www.epam.com/careers";

        public Button FindYourDreamJob => new Button(By.CssSelector(".arrow [href*='job-listings'][tabindex='0']"));
    }
}
