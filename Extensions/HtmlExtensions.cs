using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Extensions
{
    public static class HtmlExtensions
    {
        public static HtmlString GetPersianNumbering(this IHtmlHelper html, int number, int startFrom = 0)
        {
            var numberingArray = new string[] { "اول","دوم" ,"سوم","چهارم","پنجم","ششم","هفتم","هشتم","نهم","دهم","یازدهم"};
            return new HtmlString(numberingArray[number + startFrom]);
        }
    }
}
