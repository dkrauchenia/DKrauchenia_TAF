using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Pages.Pages;

namespace Epam.TestAutomation.Tests
{
    [TestFixture]
    public class PagesNavigationTests : BaseTest
    {
        private MainPage _mainPage;
        private CareersPage _careersPage;
        private ClientsWorkPage _clientsWorkPage;

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage();
            _careersPage = new CareersPage();
            _clientsWorkPage = new ClientsWorkPage();
            _mainPage.AcceptAllCookies();
        }

        [Test]
        public void VerifyThatMainPageIsOpened() 
        {
            Assert.That(_mainPage.IsOpened(), "Main Page is not opened!");
        }

        [Test]
        public void VerifyNavigationBetweenPages()
        {
            Browser.Instance.GoToUrl(_careersPage.Url);
            Browser.Instance.GoToUrl(_clientsWorkPage.Url);
            Browser.Instance.Refresh();
            Browser.Instance.Back();

            Assert.That(Browser.Instance.Url, Is.EqualTo(_careersPage.Url), "Redirected to incorrect page!");
        }
    }
}
