using Newtonsoft.Json;

namespace SeleniumCSharp.Models
{
    [Serializable]
    public class PlaceModel
    {
        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("state")]
        public string? State { get; set; }

        [JsonProperty("places")]
        public List<SubPlace>? SubPlaces { get; set; }

        [Serializable]
        public class SubPlace
        {
            [JsonProperty("place name")]
            public string? PlaceName { get; set; }

            [JsonProperty("post code")]
            public string? PostCode { get; set; }
        }
    }
}