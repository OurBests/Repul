using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IPaymentService _paymentService;
        public PersonalPortalController(IPersonalPortalService personalPortalService, IPaymentService paymentService)
        {
            _personalPortalService = personalPortalService;
            _paymentService = paymentService;
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
        public async Task<IActionResult> Add([FromBody] AddPersonalPortalModel model)
        {
            model.ID = User.Claims.GetUserId();
            model.Hash = User.Claims.GetUserHash();
            var result = await _personalPortalService.AddPersonalPortal(model);
            return Json(result);
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("PersonalPortal/Pay/{PersonalPortalId}")]
        public async Task<IActionResult> Pay([FromRoute] PayModel model)
        {
            var result = await _personalPortalService.GetPersonalPortal(model);
            return View(result);
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("PersonalPortal/Pay/{PersonalPortalId}")]
        public async Task<IActionResult> Pay([FromRoute] PayModel model, [FromForm] PersonalPortalModel bodyModel)
        {
            string mechantId = "dd5c225c-bbf5-11e9-9621-000c295eb8fc";
            var personalPortal = await _personalPortalService.GetPersonalPortal(model);
            bodyModel.Price = !string.IsNullOrEmpty(personalPortal.Price) ? personalPortal.Price : bodyModel.Price;
            bodyModel.Description = !string.IsNullOrEmpty(personalPortal.Description) ? personalPortal.Description : bodyModel.Description;
            var payment = new Zarinpal.Payment(mechantId, int.Parse(bodyModel.Price));

            var retUrl = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, $"PersonalPortal/PayReturn");

            var requestResult = await payment.PaymentRequest(bodyModel.Description, retUrl);
            if (requestResult.Status == 100)
            {
                await _paymentService.CreateRequest(new CreateRequest
                {
                    Status = requestResult.Status,
                    Authority = requestResult.Authority,
                    Link = requestResult.Link,
                    PersonalPortalId = personalPortal.ID,
                    Description = bodyModel.Description,
                    Price = bodyModel.Price
                });
                return Redirect(requestResult.Link);
            }
            return View(bodyModel);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> PayReturn([FromQuery] PayReturnModel model)
        {
            var verfyResult = await _paymentService.VerifyRequest(model);
            return View(verfyResult);
        }
    }
}