using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using web.Extensions;
using web.Filters;
using web.Interfaces;
using web.Models;

namespace web.Controllers
{
    [Authorize]
    public class BankAccountsController : Controller
    {
        private readonly IBankAccountService _bankAccountService;
        public BankAccountsController(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }
        [VirtualDom]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAccounts()
        {
            var userId = User.Claims.GetUserId();
            var hash = User.Claims.GetUserHash();
            var result = await _bankAccountService.GetUserAccounts(new Models.GetBankAccountModel
            {
                ID = userId,
                Hash = hash
            });
            return Json(result);
        }
        public async Task<IActionResult> Add([FromBody] AddAccountModel model)
        {
            model.ID = User.Claims.GetUserId();
            model.Hash = User.Claims.GetUserHash();
            var result = await _bankAccountService.AddAccount(model);
            return Json(result);
        }
    }
}