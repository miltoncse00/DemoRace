using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRace.Common
{
    public class HorseSummary
    {
        [JsonProperty(PropertyName ="id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "betcount")]
        public decimal BetCount { get; set; }
        [JsonProperty(PropertyName = "payout")]
        public decimal PayOut { get; set; }
    }
}
