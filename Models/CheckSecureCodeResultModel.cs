using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class CheckSecureCodeResultModel
    {
        public string ID { get; set; }
        public string Username { get; set; }
        public string Avatar { get; set; }
        public string NameShop { get; set; }
        public string NatCode { get; set; }
        public string PicNatCode { get; set; }
        public string Money { get; set; }
        public bool  Active { get; set; }
        public string Status { get; set; }
        public string Hash { get; set; }
    }
}
