using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using web.Interfaces;
using web.Models;

namespace web.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IRequestManagerService _requestManagerService;
        public ProfileService(IRequestManagerService requestManagerService)
        {
            _requestManagerService = requestManagerService;
        }
        public async Task<UserProfileModel> GetUserProfile(ServiceRequest reqModel)
        {
            var result = await _requestManagerService.Post<ServiceResponse<UserProfileModel>>("/profile_get", reqModel);
            return result.DataModel;
        }

        public async Task UpdateField(UpdateFieldModel model)
        {
            await _requestManagerService.Post<ServiceResponse<object>>("/profile_edit", model);
        }

        public async Task UploadAvatar(IFormFile image, ServiceRequest reqModel)
        {
            await _requestManagerService.Post("/avatar_upload", reqModel, image);
        }
    }
}
