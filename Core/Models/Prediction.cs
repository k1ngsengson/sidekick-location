using System.Collections.Generic;

namespace Core.Models
{
    public class Prediction
    {

        [Newtonsoft.Json.JsonProperty("id")]
        public string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("matched_substrings")]
        public List<PlacesMatchedSubstring> MatchedSubstrings { get; set; }

        [Newtonsoft.Json.JsonProperty("place_id")]
        public string PlaceId { get; set; }

        [Newtonsoft.Json.JsonProperty("reference")]
        public string Reference { get; set; }

        [Newtonsoft.Json.JsonProperty("terms")]
        public List<PlacesTerm> Terms { get; set; }

        [Newtonsoft.Json.JsonProperty("types")]
        public List<string> Types { get; set; }
    }
}
