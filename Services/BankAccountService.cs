using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Interfaces;
using web.Models;

namespace web.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IRequestManagerService _requestManagerService;
        public BankAccountService(IRequestManagerService requestManagerService)
        {
            _requestManagerService = requestManagerService;
        }
        public async Task<AccountModel> GetUserAccounts(string userId)
        {
            var result = await _requestManagerService.Post<AccountModel>("/accounts_get", new { ID = userId });
            return result;
        }
    }
}
