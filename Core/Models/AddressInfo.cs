using Newtonsoft.Json.Linq;

namespace Core.Models
{
    public class AddressInfo
    {

        public string Address { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }
        public string Json { get; set; }

        public AddressInfo(JObject jsonObject)
        {
            Address = (string)jsonObject["result"]["name"];
            Latitude = (double)jsonObject["result"]["geometry"]["location"]["lat"];
            Longitude = (double)jsonObject["result"]["geometry"]["location"]["lng"];
            Json = jsonObject.ToString();
        }
    }
}
