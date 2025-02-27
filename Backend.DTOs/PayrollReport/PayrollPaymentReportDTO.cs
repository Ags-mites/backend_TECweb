using System.Collections.Generic;

namespace Backend.DTOs.PayrollReport
{
    public class PayrollPaymentReportDTO
    {
        public string WorkerName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
    }
}