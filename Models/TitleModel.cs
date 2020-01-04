using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class TitleModel: ServiceRequest
    {
        public string Title { get; set; }
    }
    public class TitleUniqueModel
    {
        public bool IsUnique { get; set; }
    }
}
