using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Interfaces;
using web.Models;

namespace web.Services
{
    public class PersonalPortalService : IPersonalPortalService
    {
        private readonly IRequestManagerService _requestManagerService;
        public PersonalPortalService(IRequestManagerService requestManagerService)
        {
            _requestManagerService = requestManagerService;
        }
        public async Task<PersonalPortalModel> AddPersonalPortal(AddPersonalPortalModel model)
        {
            var result = await _requestManagerService.Post<ServiceResponse<PersonalPortalModel>>("/portal_add", model);
            return result.DataModel;
        }

        public async Task<PersonalPortalModel> GetPersonalPortal(PayModel model)
        {
            var result = await _requestManagerService.Post<ServiceResponse<IEnumerable<PersonalPortalModel>>>("/portal_get_one", model);
            return result.DataModel.FirstOrDefault();
        }

        public async Task<IEnumerable<PaymentModel>> GetPortalTransactions(PayModel payModel)
        {
            var result = await _requestManagerService.Post<ServiceResponse<IEnumerable<PaymentModel>>>("/portal_get_trans", payModel);
            return result.DataModel;
        }

        public async Task<IEnumerable<PersonalPortalModel>> GetUserPersonalPortals(GetPersonalPortalModel model)
        {
            var result = await _requestManagerService.Post<ServiceResponse<IEnumerable<PersonalPortalModel>>>("/portal_get", model);
            return result.DataModel;
        }
    }
}
