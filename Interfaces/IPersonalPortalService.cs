using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Models;

namespace web.Interfaces
{
    public interface IPersonalPortalService
    {
        Task<IEnumerable<PersonalPortalModel>> GetUserPersonalPortals(GetPersonalPortalModel model);
        Task<PersonalPortalModel> AddPersonalPortal(AddPersonalPortalModel model);
    }
}
