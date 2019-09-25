using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class LoginStepOneModel
    {
        [Required]
        public string Phone { get; set; }
        public string Version => "1";
    }
}
