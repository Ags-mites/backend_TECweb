using Backend.DTOs.AccountReports;
using Backend.DTOs.PayrollReport;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
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
        private readonly IReportService<PayrollPaymentReportDTO> _payrollPaymentReportService;
        private readonly IReportService<PayrollReasonCrossReportDTO> _payrollReasonCrossReportService;

        public ReportController(
            IReportService<BalanceSheetReportDTO> balanceSheetReportService,
            IReportService<IncomeStatementReportDTO> incomeStatementReportService,
            IReportService<PayrollPaymentReportDTO> payrollPaymentReportService,
            IReportService<PayrollReasonCrossReportDTO> payrollReasonCrossReportService)
        {
            _balanceSheetReportService = balanceSheetReportService;
            _incomeStatementReportService = incomeStatementReportService;
            _payrollPaymentReportService = payrollPaymentReportService;
            _payrollReasonCrossReportService = payrollReasonCrossReportService;
        }

        [HttpGet("balanceSheet/all")]
        public async Task<ActionResult<List<BalanceSheetReportDTO>>> GetBalanceSheetReport(
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate)
        {
            var report = await _balanceSheetReportService.GenerateGroupedReportAsync(startDate, endDate);
            return Ok(report);
        }

        [HttpGet("incomeStatement/all")]
        public async Task<ActionResult<List<IncomeStatementReportDTO>>> GetIncomeStatementReport(
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate)
        {
            var report = await _incomeStatementReportService.GenerateGroupedReportAsync(startDate, endDate);
            return Ok(report);
        }

        [HttpGet("payroll/payments/all")]
        public async Task<ActionResult<List<PayrollPaymentReportDTO>>> GetPayrollPaymentReport(
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate)
        {
            var report = await _payrollPaymentReportService.GenerateGroupedReportAsync(startDate, endDate);
            return Ok(report);
        }

        [HttpGet("payroll/reasonCross/all")]
        public async Task<ActionResult<List<PayrollReasonCrossReportDTO>>> GetPayrollReasonCrossReport(
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate)
        {
            var report = await _payrollReasonCrossReportService.GenerateGroupedReportAsync(startDate, endDate);
            return Ok(report);
        }
    }
}
