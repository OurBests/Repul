using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.DataAnnotations;

namespace web.Models
{
    public class AddPersonalPortalModel : ServiceRequest
    {
        public string Help { get; set; }
        [PriceUnformatter]
        public string Price { get; set; }
        public string AccountId { get; set; }
        public string Description{ get; set; }
        public string Title { get; set; }
    }
}
