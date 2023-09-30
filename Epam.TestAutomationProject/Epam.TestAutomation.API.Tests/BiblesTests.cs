using Epam.TestAutomation.API.Controllers;
using Epam.TestAutomation.API.ResponseModels;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace Epam.TestAutomation.API.Tests
{
    [TestFixture]
    public class BiblesTests
    {
        [Test]
        public void CheckAllBiblesResponceWithValidParams()
        {
            var response = new BiblesController(new CustomRestClient()).GetBibles<RestResponse>();
            Assert.That(response.response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code was returned while sending GET request to /v1/bibles!");
        }

        [Test]
        public void CheckAllBiblesResponseWithoutAuthorization()
        {
            var response = new BiblesController(new CustomRestClient(), string.Empty).GetBibles<RestResponse>();
            Assert.That(response.response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized), "Invalid status code was returned while sending GET request to '/v1/bibles' without authorization!");
        }

        [Test]
        public void CheckAllBiblesResponseReturnObject()
        {
            var response = new BiblesController(new CustomRestClient()).GetBibles<AllBiblesModel>();
            CollectionAssert.IsNotEmpty(response.Bibles.data, "Any bible should be returned after sending GET request to '/v1/bibles!'");
        }

        [Test]
        public void CheckAudioBiblesResponceWithValidParams()
        {
            var response = new BiblesController(new CustomRestClient()).GetAudioBibles<RestResponse>();
            Assert.That(response.response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code was returned while sending GET request to '/v1/audio-bibles'!");
        }

        [Test]
        public void CheckAudioBiblesResponceWithoutAuthorization()
        {
            var response = new BiblesController(new CustomRestClient(), string.Empty).GetAudioBibles<RestResponse>();
            Assert.That(response.response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized), "Invalid status code was returned while sending GET request to '/v1/audio-bibles' without authorization!");
        }

        [Test]
        public void CheckAudioBiblesBooksResponceWithValidParams()
        {
            var controller = new BiblesController(new CustomRestClient());
            var bibleId = controller.GetAudioBibles<AllBiblesModel>().Bibles.data.Select(bible => bible.id).FirstOrDefault();
            var response = controller.GetAudioBibleBooks<RestResponse>(bibleId);
            Assert.That(response.response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code was returned while sending GET request to '/v1/audio-bibles/{audioBibleId}/books'!");
        }


    }
}
