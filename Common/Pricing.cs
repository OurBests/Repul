using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Common
{
    public static class Pricing
    {
        public static long CalcWagePrice(long price)
        {
            var oc = price / 1000000;
            return 500 + ((oc - 1) * 200);

        }
    }
}
