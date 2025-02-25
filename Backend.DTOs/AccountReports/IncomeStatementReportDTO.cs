namespace Backend.DTOs.AccountReports
{
    public class IncomeStatementReportDTO
    {
        public string AccountTypeName { get; set; }
        public List<AccountReportDTO> Accounts { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal NetIncome => TotalRevenue - TotalExpenses;
    }
}
