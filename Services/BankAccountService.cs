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
        public async Task<IEnumerable<AccountModel>> GetUserAccounts(GetBankAccountModel userId)
        {
            var result = await _requestManagerService.Post<ServiceResponse<IEnumerable<AccountModel>>>("/accounts_get", userId );
            return result.DataModel;
        }
    }
}
