using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Interfaces;
using web.Models;

namespace web.Services
{
    public class ReportService : IReportService
    {
        private readonly IRequestManagerService _requestManagerService;
        public ReportService(IRequestManagerService requestManagerService)
        {
            _requestManagerService = requestManagerService;
        }
        public async Task<ReportTotalModel> GetTotals(ServiceRequest requestModel)
        {
            var result = await _requestManagerService.Post<ServiceResponse<ReportTotalModel>>("/dashboard_total", requestModel);
            return result.DataModel;
        }

        public async Task<IEnumerable<DatePayModel>> GetYearPays(ServiceRequest requestModel)
        {
            var result = await _requestManagerService.Post<ServiceResponse<IEnumerable<DatePayModel>>>("/dashboard_yearpays", requestModel);
            return result.DataModel;
        }
    }
}
