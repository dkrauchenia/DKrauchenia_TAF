using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.Pages
{
    public class CareersPage : BasePage
    {
        public override string Url => "https://www.epam.com/careers";

        public Button FindYourDreamJob => new Button(By.XPath("//div[@class='owl-item active']//a[@href='/careers/job-listings']"));

    }
}
