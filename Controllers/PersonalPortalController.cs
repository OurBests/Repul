using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web.Extensions;
using web.Filters;
using web.Interfaces;
using web.Models;

namespace web.Controllers
{
    public class PersonalPortalController : Controller
    {
        private readonly IPersonalPortalService _personalPortalService;
        public PersonalPortalController(IPersonalPortalService personalPortalService)
        {
            _personalPortalService = personalPortalService;
        }
        [VirtualDom]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetPersonalPortals()
        {
            var userId = User.Claims.GetUserId();
            var hash = User.Claims.GetUserHash();
            var result = await _personalPortalService.GetUserPersonalPortals(new Models.GetPersonalPortalModel
            {
                ID = userId,
                Hash = hash
            });
            return Json(result);
        }
    }
}