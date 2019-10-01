using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Models;
using Zarinpal.Models;

namespace web.Interfaces
{
    public interface IPaymentService
    {
        Task CreateRequest(CreateRequest requestModel);
        Task<VerifyRequestModel> VerifyRequest(PayReturnModel model);
    }
}
