using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class CreateRequest
    {
        public int Status { get; internal set; }
        public string Authority { get;  set; }
        public string Link { get;  set; }
        public string PersonalPortalId { get;  set; }
        public string DestinationPortalId { get;  set; }
        public string Description { get;  set; }
        public string Price { get;  set; }
        public string GroupId { get; internal set; }
    }
}
