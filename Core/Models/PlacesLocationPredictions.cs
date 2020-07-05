using System.Collections.Generic;

namespace Core.Models
{
    public class PlacesLocationPredictions
    {

        [Newtonsoft.Json.JsonProperty("predictions")]
        public List<Prediction> Predictions { get; set; }

        [Newtonsoft.Json.JsonProperty("status")]
        public string Status { get; set; }
    }
}
