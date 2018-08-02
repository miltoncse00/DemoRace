using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRace.Common
{
    public class Race
    {
        [JsonProperty(PropertyName ="Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName ="name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName ="start")]
        public DateTime Start { get; set; }
        [JsonProperty(PropertyName ="status")]
        public string Status { get; set; }
        [JsonProperty(PropertyName ="horses")]
        IList<Horse> Horses { get; set; }
    }
}
