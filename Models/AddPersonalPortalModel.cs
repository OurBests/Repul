using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class AddPersonalPortalModel : ServiceRequest
    {
        public string Help { get; set; }
        public string Price { get; set; }
        public string AccountId { get; set; }
        public string Description{ get; set; }
    }
}
