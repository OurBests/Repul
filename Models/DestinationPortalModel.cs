using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Common;

namespace web.Models
{
    public class DestinationPortalModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("dportalId")]
        public string DestinationPortalId { get; set; }

        [JsonProperty("iban_code")]
        public string IbanCode { get; set; }
        public string Title { get; set; }
        public long Price { get; set; }
        public string CreatedAt { get; set; }
        public string JCreatedAt => DateUtils.ToJalaliString(CreatedAt);
        public IEnumerable<PaymentModel> Payments { get; set; }
        public IEnumerable<GroupModel> Groups { get; set; }
        public string Group => Groups?.FirstOrDefault()?.Name;
        public string GroupId => Groups?.FirstOrDefault()?.Id;
        public IEnumerable<PaymentModel> GroupPays { get; set; }
        public long GroupPaid { get { return GroupPays.Where(x => x.ResultStatus == "OK").Sum(x => x.Price); } }
        public string Phone { get; set; }
    }
}
