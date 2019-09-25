using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Models;

namespace web.Interfaces
{
    public interface ITwoStepVerificationService
    {
        Task<CreateSecureCodeResultModel> CreateSecureCode(LoginStepOneModel model);
        Task<CheckSecureCodeResultModel> CheckSecureCode(LoginStepTwoModel model);
        Task<RegistrationResultModel> Register(RegistrationModel model);
    }
}
