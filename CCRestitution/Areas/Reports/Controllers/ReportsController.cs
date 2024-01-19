using CCRestitution.Data;
using CCRestitution.Models;
using CCRestitution.ReportsRepository;
using CCRestitution.Services.ReportsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using System.Linq.Expressions;

namespace CCRestitution.Area.Reports.Controllers
{
    [Area("Reports")]
    public class ReportsController : Controller
    {
        private readonly DataContext _context;
        private readonly IReportsService _reportsService;

        public ReportsController(DataContext context, IReportsService reportsService)
        {
            _context = context;
            _reportsService = reportsService;
        }

        public async Task<IActionResult> Index()
        {


            return View();
        }


        [HttpGet("/Reports/Generate/{ReportName}/{StartDate}/{EndDate?}")]
        public async Task<IActionResult> GenerateReport(string ReportName, DateTime StartDate, DateTime? EndDate)
        {
            var document = await _reportsService.LogDischTransMoAsync(StartDate, EndDate);
            //document.GeneratePdf();
            document.ShowInPreviewer();

            return Ok();
        }

    }
}
