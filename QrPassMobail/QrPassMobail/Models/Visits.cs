using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QrPassMobail.Models
{
    public class Visits
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("visit_date")]
        public DateTime Date { get; set; }
        [JsonProperty("_id")]
        public string id { get; set; }


        public bool IsEnter { get; set; }
    }
}
