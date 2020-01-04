using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Common;

namespace web.Models
{
    public class DatePayModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string JDate => DateUtils.ToJalaliDate(Date);
        public string JDateYear => !string.IsNullOrEmpty(JDate) ? JDate.Split("/")[0] : null;
        public string JDateMonthName => !string.IsNullOrEmpty(JDateYear) ? DateUtils.GetMonthName(int.Parse(JDate.Split("/")[1])) : null;
        public string JDateMonthYear => $"{JDateMonthName} {JDateYear}";

        public long Price { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string PersianType
        {
            get
            {
                var t = new Dictionary<string, string>() { { "portal", "درگاه شخصی" }, { "dportal", "حساب مقصد" }, { "group", "پرداخت گروهی" } };
                return t[Type];
            }
        }
    }
}
