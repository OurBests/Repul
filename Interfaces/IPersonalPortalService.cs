﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web.Models;

namespace web.Interfaces
{
    public interface IPersonalPortalService
    {
        Task<IEnumerable<PersonalPortalModel>> GetUserPersonalPortals(GetPersonalPortalModel model);
        Task<PersonalPortalModel> AddPersonalPortal(AddPersonalPortalModel model);
        Task<PersonalPortalModel> GetPersonalPortal(PayModel model);
        Task<IEnumerable<PaymentModel>> GetPortalTransactions(PayModel payModel);
        Task<string> DeletePersonalPortal(GetPersonalPortalModel model);
        Task<TitleUniqueModel> CheckTitleIsUnqiue(TitleModel model);
    }
}
