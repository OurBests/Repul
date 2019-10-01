﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Models;

namespace web.Interfaces
{
    public interface IDestinationPortalService
    {
        Task<IEnumerable<DestinationPortalModel>> GetUserRegistredPortals(GetDestinationPortalModel serviceRequest);
        Task<DestinationPortalModel> AddDestinationPortal(AddDestinationPortalModel model);
        Task<DestinationPortalModel> GetUserRegistredPortal(GetDestinationPortalModel model);
    }
}