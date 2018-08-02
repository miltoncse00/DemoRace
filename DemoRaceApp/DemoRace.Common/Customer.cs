using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRace.Common
{
    public class Customer
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
