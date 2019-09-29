using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Common;

namespace web.Models
{
    public class AccountModel
    {
        [JsonProperty("_id")]
        public string ID { get; set; }
        public string Account { get; set; }
        public string Bank{ get; set; }
        public string OwnerName{ get; set; }
        public string IBAN_code { get; set; }
        public string Bank_code { get; set; }
        public string NationalCode { get; set; }
        public string Birthdate { get; set; }
        public string JBirthdate => DateUtils.ToJalaliString(Birthdate);

        public string Userid { get; set; }
        public string CreatedAt { get; set; }
        public string JCreatedAt => DateUtils.ToJalaliString(CreatedAt);
        public string AccountId { get; set; }
    }
}
