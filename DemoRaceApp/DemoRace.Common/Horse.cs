using Newtonsoft.Json;

namespace DemoRace.Common
{
    public class Horse
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "odds")]
        public decimal Odds { get; set; }
    }
}