using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Models;

namespace web.Interfaces
{
    public interface IReportService
    {
        Task<ReportTotalModel> GetTotals(ServiceRequest requestModel);
        Task<IEnumerable<DatePayModel>> GetYearPays(ServiceRequest requestModel);
    }
}
