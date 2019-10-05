using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using web.Filters;

namespace web.Controllers
{
    [Authorize]
    public class SettingController : Controller
    {
        [VirtualDom]
        public IActionResult Index()
        {
            return View();
        }
    }
}