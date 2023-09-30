using Epam.TestAutomation.API.ResponseModels;
using Newtonsoft.Json;

namespace Epam.TestAutomation.API.RequestModels
{
    public class TechObjectReqModel
    {
        public string Name { get; set; }
        public PhoneData Data { get; set; }
    }
}
