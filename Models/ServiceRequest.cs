using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class ServiceRequest
    {
        public string Hash { get; set; }
        public string Version => "1";
    }
}
