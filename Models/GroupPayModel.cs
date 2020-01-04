using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class GroupPayModel:ServiceRequest
    {
        [FromRoute]
        public string GroupId { get; set; }
        [FromForm]
        public long? Price { get; set; }
    }
}
