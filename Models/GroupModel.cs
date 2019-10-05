using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class GroupModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
