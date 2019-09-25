using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Models;

namespace web.Interfaces
{
    public interface IBankAccountService
    {
        Task<AccountModel> GetUserAccounts(string userId);
    }
}
