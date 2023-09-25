using RestSharp;

namespace Epam.TestAutomation.API.Controllers
{
    public class TechController : BaseController
    {
        public TechController(CustomRestClient client) : base(client, Service.Tech)
        {

        }

        private const string PhoneResource = "/objects";
        private const string SiglePhoneResource = "/objects/{0}";

        /// <summary>
        /// Receive list of all phones
        /// </summary>
        /// <typeparam name="T"><see cref="TechItemModel"/> </typeparam>
        /// <returns>response typeof <see cref="RestResponse"/> and <see cref="TechItemModel"/></returns>
        public (RestResponse Response, T? TechModel) GetTechItems<T>()
        {
            return Get<T>(PhoneResource);
        }

        /// <summary>
        /// Receive single phone by id
        /// </summary>
        /// <typeparam name="T"><see cref="TechItemModel"></typeparam>
        /// <returns>response typeof <see cref="RestResponse"/> and <see cref="TechItemModel"/></returns>
        public (RestResponse Response, T? TechModel) GetSingleTechItem<T>(string phoneId)
        {
            return Get<T>(string.Format(SiglePhoneResource, phoneId));
        }


    }
}
