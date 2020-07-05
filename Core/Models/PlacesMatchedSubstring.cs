namespace Core.Models
{
    public class PlacesMatchedSubstring
    {

        [Newtonsoft.Json.JsonProperty("length")]
        public int Length { get; set; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public int Offset { get; set; }
    }
}
