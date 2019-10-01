using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Common;

namespace web.Models
{
    public class PaymentModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        public int Status { get; set; }
        public string Authority { get; set; }
        public long LongAuthority => long.Parse(Authority);
        public string Link { get; set; }
        public string CreatedAt { get; set; }
        public string JCreatedAt => DateUtils.ToJalaliString(CreatedAt);
        public string ResultStatus { get; set; }
        public string UpdatedAt { get; set; }
        public string JUpdatedAt => DateUtils.ToJalaliString(UpdatedAt);
        public string Description { get; set; }
        public string Price{ get; set; }

    }
}
