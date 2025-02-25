using Backend.DTOs.AccountReports;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/reports")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService<BalanceSheetReportDTO> _balanceSheetReportService;
        private readonly IReportService<IncomeStatementReportDTO> _incomeStatementReportService;

        public ReportController(
            IReportService<BalanceSheetReportDTO> balanceSheetReportService,
            IReportService<IncomeStatementReportDTO> incomeStatementReportService)
        {
            _balanceSheetReportService = balanceSheetReportService;
            _incomeStatementReportService = incomeStatementReportService;
        }

        [HttpGet("balanceSheet/all")]
        public async Task<ActionResult<List<BalanceSheetReportDTO>>> GetBalanceSheetReport()
        {
            var report = await _balanceSheetReportService.GenerateGroupedReportAsync();
            return Ok(report);
        }

        [HttpGet("incomeStatement/all")]
        public async Task<ActionResult<List<IncomeStatementReportDTO>>> GetIncomeStatementReport()
        {
            var report = await _incomeStatementReportService.GenerateGroupedReportAsync();
            return Ok(report);
        }
    }

}
