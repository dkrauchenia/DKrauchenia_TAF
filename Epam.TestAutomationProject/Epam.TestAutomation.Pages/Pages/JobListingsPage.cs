using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.Pages
{
    public class JobListingsPage : BasePage
    {
        public override string Url => "https://www.epam.com/careers/job-listings";

        public HtmlElement OurLocations => new HtmlElement(By.XPath("//div[@class='text']//span[contains(@class, 'museo-sans-light')]"));

        public ElementsList<BaseElement> TabLinks => new ElementsList<BaseElement>(By.XPath("//div[contains(@class,'tabs-links-list')]//a"));

        public Button RegisterYourInterest => new Button(By.XPath("//a[contains(@class, 'button-ui-23') and contains(@href, 'apply-now')]"));

    }
}
