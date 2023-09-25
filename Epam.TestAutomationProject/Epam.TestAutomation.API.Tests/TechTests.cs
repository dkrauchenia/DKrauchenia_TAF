using Epam.TestAutomation.API.Controllers;
using Epam.TestAutomation.API.ResponseModels;
using NUnit.Framework;
using System.Net;

namespace Epam.TestAutomation.API.Tests
{
    [TestFixture]
    public class TechTests
    {
        [Test]
        public void VerifyAllTechItemsAreReturned()
        {
            var response = new TechController(new CustomRestClient()).GetTechItems<List<TechItemModel>>();
            Assert.That(response.TechModel?.Any(), Is.True, "Invalid data!");
        }

        [Test]
        public void VerifyPhoneObjectsResponse()
        {
            var response = new TechController(new CustomRestClient()).GetTechItems<List<TechItemModel>>();
            Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code data!");
        }

        [Test]
        public void VerifyCorrectNumberOfObjectsReturned()
        {
            var expectedObjectsNum = 13;
            var response = new TechController(new CustomRestClient()).GetTechItems<List<TechItemModel>>();
            var actualObjectsNum = response.TechModel.Select(a => a.id).ToList().Count();
            Assert.That(expectedObjectsNum, Is.EqualTo(actualObjectsNum), $"Number of objects is invalid!'");
        }
    }
}
