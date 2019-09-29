using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace web.Common
{
    public static class DateUtils
    {
        public static DateTime ToGregorianDate(string jalali)
        {
            var splited = jalali.Replace("-", "/").Split('/');
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = new DateTime(int.Parse(splited[0]), int.Parse(splited[1]), int.Parse(splited[2]), pc);
            return dt;
        }
        public static string ToGregorianString(string jalali)
        {
            return ToGregorianDate(jalali).ToString(CultureInfo.InvariantCulture);
        }
        public static string ToJalaliDate(DateTime gregorianDate)
        {
            var calendar = new PersianCalendar();
            return
                $"{calendar.GetYear(gregorianDate).ToString("0000")}/{calendar.GetMonth(gregorianDate).ToString("00")}/{calendar.GetDayOfMonth(gregorianDate).ToString("00")}";
        }
        public static string ToJalaliString(string gregorianDate)
        {
            var calendar = new PersianCalendar();
            var date = DateTime.Parse(gregorianDate);
            return
                $"{calendar.GetYear(date).ToString("0000")}/{calendar.GetMonth(date).ToString("00")}/{calendar.GetDayOfMonth(date).ToString("00")}";
        }
    }
}
