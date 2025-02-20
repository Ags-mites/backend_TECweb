using Backend.DTOs.AccountReports;
using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Interfaces
{
    public interface IReportService
    {
        Task<List<BalanceSheetReportDTO>> GenerateGroupedReportAsync();
    }
}
