using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Common;

namespace web.Models
{
    public class PersonalPortalModel
    {
        [JsonProperty("_id")]
        public string ID { get; set; }
        public string UserId { get; set; }
        public string Accountid { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Help { get; set; }
        public string CreatedAt { get; set; }
        public string JCreatedAt => DateUtils.ToJalaliString(CreatedAt);
        public IEnumerable<AccountModel> Account { get; set; }
        public AccountModel FirstAccount => Account?.FirstOrDefault();
        public IEnumerable<PaymentModel> Payments { get; set; }
    }
}
