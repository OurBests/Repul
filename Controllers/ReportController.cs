using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web.Extensions;
using web.Filters;
using web.Interfaces;
using web.Models;

namespace web.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        [VirtualDom]
        public async Task<IActionResult> Index()
        {
            var requestModel = new ServiceRequest
            {
                Hash = User.Claims.GetUserHash(),
                ID = User.Claims.GetUserId()
            };
            ViewBag.Totals = await _reportService.GetTotals(requestModel);
            ViewBag.YearPays = await _reportService.GetYearPays(requestModel);
            return View();
        }
        public async Task<IActionResult> GetTotals()
        {
            var requestModel = new ServiceRequest
            {
                Hash = User.Claims.GetUserHash(),
                ID = User.Claims.GetUserId()
            };
            var totals = await _reportService.GetTotals(requestModel);
            return null;
        }
    }
}