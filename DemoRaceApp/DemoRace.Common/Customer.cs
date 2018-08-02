using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRace.Common
{
    public class Customer
    {
        [JsonProperty(PropertyName = "id")]
        int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        string Name { get; set; }
    }
}
