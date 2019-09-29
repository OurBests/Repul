using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using web.Common;

namespace web.Models
{
    public class AddAccountModel : ServiceRequest
    {
        public string NatCode { get; set; }
        public string BankId { get; set; }
        public string AccountId { get; set; }
        public string IBANCode { get; set; }
        public string Birthdate { get; set; }
        public string GBirthdate => DateUtils.ToGregorianString(Birthdate);
        public string CardNo { get; set; }
    }
}
