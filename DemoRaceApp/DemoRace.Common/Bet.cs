using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DemoRace.Common
{
    public class Bet
    {
        [JsonProperty(PropertyName = "customerId")]
        public int CustomerId { get; set; }
        [JsonProperty(PropertyName = "raceId")]
        public int RaceId { get; set; }
        [JsonProperty(PropertyName = "horseId")]
        public int HorseId { get; set; }
        [JsonProperty(PropertyName = "stake")]
        public decimal Stake { get; set; }
        [JsonProperty(PropertyName = "won")]
        public bool Won { get; set; }

    }
}
