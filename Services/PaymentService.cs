using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Interfaces;
using web.Models;
using Zarinpal.Models;

namespace web.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IRequestManagerService _requestManagerService;
        public PaymentService(IRequestManagerService requestManagerService)
        {
            _requestManagerService = requestManagerService;
        }
        public async Task CreateRequest(CreateRequest requestModel)
        {
           await _requestManagerService.Post<ServiceResponse<object>>("/create_payment_request", requestModel); 
        }
        public async Task<VerifyRequestModel> VerifyRequest(PayReturnModel model)
        {
            var result = await _requestManagerService.Post<ServiceResponse<VerifyRequestModel>>("/update_payment_request", model);
            return result.DataModel;
        }
    }
}