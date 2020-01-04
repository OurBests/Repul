using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web.Extensions;
using web.Filters;
using web.Interfaces;
using web.Models;

namespace web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        [VirtualDom]
        public async Task<IActionResult> Index()
        {
            var reqModel = new ServiceRequest
            {
                Hash = User.Claims.GetUserHash(),
                ID = User.Claims.GetUserId()
            };
            var profile = await _profileService.GetUserProfile(reqModel);
            return View(profile);
        }
        public async Task<IActionResult> UpdateField([FromBody] UpdateFieldModel model)
        {
            model.Hash = User.Claims.GetUserHash();
            model.ID = User.Claims.GetUserId();
            await _profileService.UpdateField(model);
            return Ok("OK");
        }
        public async Task<IActionResult> UploadAvatar(IFormFile image)
        {
            var reqModel = new ServiceRequest
            {
                Hash = User.Claims.GetUserHash(),
                ID = User.Claims.GetUserId()
            };
            await _profileService.UploadAvatar(image, reqModel);
            return Ok("OK");
        }
    }
}