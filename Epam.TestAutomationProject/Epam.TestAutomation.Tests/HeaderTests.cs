using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Pages.Pages;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TestAutomation.Tests
{
    [TestFixture]
    public class HeaderTests : BaseTest
    {
        private MainPage _mainPage;
        private JobListingsPage _jobListingsPage;
        private Actions _actions;

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage();
            _jobListingsPage = new JobListingsPage();
            _mainPage.AcceptAllCookies();
        }
    }
}
