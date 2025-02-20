using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/reports")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("grouped")]
        public async Task<IActionResult> GetGroupedReport()
        {
            var report = await _reportService.GenerateGroupedReportAsync(); 
            return Ok(report);
        }

    }
}
