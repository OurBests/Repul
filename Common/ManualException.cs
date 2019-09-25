using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Common
{
    public class ManualException : Exception
    {
        public ManualException(string message) : base(message)
        {
        }
    }
}
