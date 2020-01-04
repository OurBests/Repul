using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using web.Models;

namespace web.Interfaces
{
    public interface IProfileService
    {
        Task<UserProfileModel> GetUserProfile(ServiceRequest reqModel);
        Task UpdateField(UpdateFieldModel model);
        Task UploadAvatar(IFormFile image, ServiceRequest reqModel);
    }
}
