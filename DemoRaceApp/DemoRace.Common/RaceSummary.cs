using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRace.Common
{
    public class RaceSummary
    {
        [JsonProperty(PropertyName ="status")]
        public string Status { get; set; }
        
        [JsonProperty(PropertyName = "stake")]
        public decimal Stake { get; set; }

        [JsonProperty(PropertyName = "horses")]
        public IList<HorseSummary> Hourses { get; set; }
    }
}
