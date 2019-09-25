using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class LoginStepTwoModel : LoginStepOneModel
    {
        public string SecureCode { get; set; }
    }
}
