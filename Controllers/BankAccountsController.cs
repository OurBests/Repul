using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web.Extensions;
using web.Filters;
using web.Interfaces;

namespace web.Controllers
{
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
            var result = await _bankAccountService.GetUserAccounts(userId);
            return Json(result);
        }
    }
}