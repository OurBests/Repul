using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class UpdateFieldModel : ServiceRequest
    {
        public string NameField { get; set; }
        public string Value { get; set; }
    }
}
