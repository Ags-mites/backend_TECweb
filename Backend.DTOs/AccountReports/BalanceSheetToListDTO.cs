using System.Collections.Generic;

namespace Backend.DTOs.AccountReports
{
    public class BalanceSheetReportDTO
    {
        public string AccountTypeName { get; set; }
        public List<AccountReportDTO> Accounts { get; set; } = new();
    }

    public class AccountReportDTO
    {
        public string AccountName { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }
    }
}
