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
    public class DestinationPortalsController : Controller
    {
        private readonly IDestinationPortalService _destinationPortalService;
        private readonly IPaymentService _paymentService;
        public DestinationPortalsController(IDestinationPortalService destinationPortalService, IPaymentService paymentService)
        {
            _destinationPortalService = destinationPortalService;
            _paymentService = paymentService;
        }
        [VirtualDom]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Get()
        {
            var userId = User.Claims.GetUserId();
            var hash = User.Claims.GetUserHash();
            var result = await _destinationPortalService.GetUserRegistredPortals(new GetDestinationPortalModel
            {
                ID = userId,
                Hash = hash
            });
            return Json(result);
        }
        public async Task<IActionResult> Add([FromBody] AddDestinationPortalModel model)
        {
            model.ID = User.Claims.GetUserId();
            model.Hash = User.Claims.GetUserHash();
            var result = await _destinationPortalService.AddDestinationPortal(model);
            return Json(result);
        }
        [HttpGet]
        [Route("DestinationPortals/Pay/{DestinationPortalId}")]
        public async Task<IActionResult> Pay([FromRoute] GetDestinationPortalModel model)
        {
            model.ID = User.Claims.GetUserId();
            model.Hash = User.Claims.GetUserHash();
            var result = await _destinationPortalService.GetUserRegistredPortal(model);
            return View(result);
        }
        [HttpPost]
        [Route("DestinationPortals/Pay/{DestinationPortalId}")]
        public async Task<IActionResult> Pay([FromRoute] GetDestinationPortalModel model, [FromForm] DetinationPortalPayModel bodyModel)
        {
            model.ID = User.Claims.GetUserId();
            model.Hash = User.Claims.GetUserHash();
            string mechantId = "dd5c225c-bbf5-11e9-9621-000c295eb8fc";
            var personalPortal = await _destinationPortalService.GetUserRegistredPortal(model);
            var payment = new Zarinpal.Payment(mechantId, int.Parse(bodyModel.Price));

            var retUrl = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, $"DestinationPortals/PayReturn");

            var requestResult = await payment.PaymentRequest(personalPortal.Title, retUrl);
            if (requestResult.Status == 100)
            {
                await _paymentService.CreateRequest(new CreateRequest
                {
                    Status = requestResult.Status,
                    Authority = requestResult.Authority,
                    Link = requestResult.Link,
                    DestinationPortalId = personalPortal.Id,
                    Description = personalPortal.Title,
                    Price = bodyModel.Price
                });
                return Redirect(requestResult.Link);
            }
            return View(bodyModel);
        }
        [HttpGet]
        public async Task<IActionResult> PayReturn([FromQuery] PayReturnModel model)
        {
            var verfyResult = await _paymentService.VerifyRequest(model);
            return View(verfyResult);
        }
    }
}