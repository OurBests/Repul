using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Common;
using web.Interfaces;
using web.Models;

namespace web.Services
{
    public class TwoStepVerificationService : ITwoStepVerificationService
    {
        private readonly IRequestManagerService _requestManagerService;
        public TwoStepVerificationService(IRequestManagerService requestManagerService)
        {
            _requestManagerService = requestManagerService;
        }

      

        public async Task<CreateSecureCodeResultModel> CreateSecureCode(LoginStepOneModel model)
        {
            var result = await _requestManagerService.Post<ServiceResponse<CreateSecureCodeResultModel>>("/create_secure_code", model);
            if (result?.Code != 200)
                throw new ManualException("کد اعتبار سنجی صحیح نمیباشد!");
            return result.DataModel;

        }
        public async Task<CheckSecureCodeResultModel> CheckSecureCode(LoginStepTwoModel model)
        {
            var result = await _requestManagerService.Post<ServiceResponse<CheckSecureCodeResultModel>>("/check_secure_code", model);
            if (result?.Code != 1 && result?.Code != 200)
                throw new ManualException("خطا در ارسال کد اعتبار سنجی!");
            return result.DataModel;
        }
        public async Task<RegistrationResultModel> Register(RegistrationModel model)
        {
            var result = await _requestManagerService.Post<ServiceResponse<RegistrationResultModel>>("/register", model);
            if (result?.Code != 200)
                throw new ManualException("کد اعتبار سنجی صحیح نمیباشد!");
            return result.DataModel;
        }
    }
}
