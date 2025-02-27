using System.Collections.Generic;

namespace Backend.DTOs.PayrollReport
{
    public class PayrollReasonCrossReportDTO
    {
        public string WorkerName { get; set; } = string.Empty;
        public Dictionary<string, decimal> ReasonAmounts { get; set; } = new();
    }
}