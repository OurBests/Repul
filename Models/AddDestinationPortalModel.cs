using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class AddDestinationPortalModel:ServiceRequest
    {
        [JsonProperty("iban_code")]
        public string IBanCode { get; set; }
        public string Title { get; set; }
        public string Group { get; set; }
    }
}
