using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Interfaces;
using web.Models;

namespace web.Services
{
    public class DestinationPortalService : IDestinationPortalService
    {
        private readonly IRequestManagerService _requestManagerService;
        public DestinationPortalService(IRequestManagerService requestManagerService)
        {
            _requestManagerService = requestManagerService;
        }

        public async Task<DestinationPortalModel> AddDestinationPortal(AddDestinationPortalModel model)
        {
            var result = await _requestManagerService.Post<ServiceResponse<DestinationPortalModel>>("/dportal_add", model);
            return result.DataModel;
        }

        public async Task<string> DeleteDestinationPortal(GetDestinationPortalModel model)
        {
            var result = await _requestManagerService.Post<ServiceResponse<GetDestinationPortalModel>>("/dportal_delete", model);
            return result.DataModel.ID;
        }

        public async Task<DestinationPortalModel> EditDestinationPortal(AddDestinationPortalModel model)
        {
            var result = await _requestManagerService.Post<ServiceResponse<DestinationPortalModel>>("/dportal_edit", model);
            return result.DataModel;
        }

        public async Task<IEnumerable<DestinationPortalModel>> GetUserGroupPortals(GroupPayModel model)
        {
            var result = await _requestManagerService.Post<ServiceResponse<IEnumerable<DestinationPortalModel>>>("/dportal_get", model);
            return result.DataModel;
        }

        public async Task<IEnumerable<GroupModel>> GetUserRegistredGroups(ServiceRequest model)
        {
            var result = await _requestManagerService.Post<ServiceResponse<IEnumerable<GroupModel>>>("/groups_get", model);
            return result?.DataModel ?? new List<GroupModel>(); ;
        }

        public async Task<DestinationPortalModel> GetUserRegistredPortal(GetDestinationPortalModel model)
        {
            var result = await _requestManagerService.Post<ServiceResponse<IEnumerable<DestinationPortalModel>>>("/dportal_get", model);
            return result.DataModel.FirstOrDefault();
        }

        public async Task<IEnumerable<DestinationPortalModel>> GetUserRegistredPortals(GetDestinationPortalModel serviceRequest)
        {
            var result = await _requestManagerService.Post<ServiceResponse<IEnumerable<DestinationPortalModel>>>("/dportal_get", serviceRequest);
            return result?.DataModel?.OrderByDescending(x => x.Group).ToList() ?? new List<DestinationPortalModel>();
        }

        public async Task<DestinationPortalModel> UpdatePrice(AddDestinationPortalModel model)
        {
            var result = await _requestManagerService.Post<ServiceResponse<DestinationPortalModel>>("/dportal_update_price", model);
            return result.DataModel;


        }
    }
}
