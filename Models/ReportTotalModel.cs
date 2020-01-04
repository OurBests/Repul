using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Common;

namespace web.Models
{
    public class ReportTotalModel
    {
        public long CurrentMoney { get; set; }
        public long LastPay { get; set; }
        public string LastPayDate { get; set; }
        public string JLastPayDate => DateUtils.ToJalaliString(LastPayDate);
        public long TotalPayPortal { get; set; }
        public int TotalPayPortalCount { get; set; }
        public long TotalPayDPortal { get; set; }
        public int TotalPayDPortalCount { get; set; }
    }
}
