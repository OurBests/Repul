using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web.Filters;
using web.Interfaces;
using web.Models;

namespace web.Controllers
{
    [ManualExceptionHandler]
    public class LoginController : Controller
    {
        private readonly ITwoStepVerificationService _twoStepVerificationService;
        public LoginController(ITwoStepVerificationService twoStepVerificationService)
        {
            _twoStepVerificationService = twoStepVerificationService;
        }
        [HttpGet]
        public IActionResult StepOne()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> StepOne([FromBody] LoginStepOneModel model)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _twoStepVerificationService.CreateSecureCode(model);
            return Json(model);
        }

        [HttpGet]
        public IActionResult StepTwo(LoginStepOneModel model)
        {
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> StepTwo([FromBody] LoginStepTwoModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _twoStepVerificationService.CheckSecureCode(model);

            if (result != null )
            {
                _login(result.Username, model.Phone, result.Hash, result.ID);
                return Json(result);
            }
            else
            {
                return Json(model);
            }
        }
        public IActionResult Register(LoginStepTwoModel model)
        {
            
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegistrationModel model)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _twoStepVerificationService.Register(model);
            _login(model.Username, model.Phone, result.Hash,result.ID);
            return Json(result);
        }

        private void _login(string userName, string phone, string hash,string userId)
        {
            var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.MobilePhone, phone),
                    new Claim(ClaimTypes.Hash, hash),
                    new Claim(ClaimTypes.NameIdentifier, userId),

                }, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}