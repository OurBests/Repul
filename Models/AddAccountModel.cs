using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class AddAccountModel : ServiceRequest
    {
        public string NatCode { get; set; }
        public string BankId { get; set; }
        public string AccountId { get; set; }
        public string IBANCode { get; set; }
        public string Birthdate { get; set; }
        public string GBirthdate
        {
            get
            {
                var splited = Birthdate.Replace("-", "/").Split('/');
                PersianCalendar pc = new PersianCalendar();
                DateTime dt = new DateTime(int.Parse(splited[0]), int.Parse(splited[1]), int.Parse(splited[2]), pc);
                return dt.ToString(CultureInfo.InvariantCulture);
            }
        }
        public string CardNo { get; set; }
    }
}
