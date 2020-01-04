using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class UserProfileModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string NatCode { get; set; }
        public string NameShop { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameFather { get; set; }
        public string BirthDay { get; set; }
        public string CardBank { get; set; }
        public string HesabBank { get; set; }
        public string ShebaBank { get; set; }
        public string PicNatCode { get; set; }
        public string PicShenasname { get; set; }
        public string Avatar { get; set; }
        public long Money { get; set; }
        public string Active { get; set; }
        public string Status { get; set; }
        public string DateJoin { get; set; }
        public string LastLogin { get; set; }
        public string updated_at { get; set; }
        public string LastConnect { get; set; }

    }
}
