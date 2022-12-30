using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrPassMobail.Models
{
    public class UserDto
    {
      

       

        [JsonProperty("username")]
        public string UserName { get; set; }=string.Empty;
        [JsonProperty("password")]
        public string Password { get; set; } = string.Empty;
        [JsonProperty("isadmin")]
        public bool IsAdmin { get; set; }

        [JsonProperty("isterminal")]
        public bool IsTerminal { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }=Guid.NewGuid().ToString();   



    }
    
}
