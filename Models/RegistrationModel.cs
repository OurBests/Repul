using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class RegistrationModel : LoginStepTwoModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        [Range(0,int.MaxValue)]
        public string NatCode { get; set; }
        [Required]
        public string Username { get; set; }
    }
}
