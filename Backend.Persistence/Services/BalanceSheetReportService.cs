using Backend.DTOs.AccountReports;
using Backend.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Persistence.Services
{
    public class BalanceSheetReportService : IBalanceSheetReportRepository
    {
        private readonly DataContext _context;

        public BalanceSheetReportService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<BalanceSheetReportDTO>> GenerateGroupedReportAsync()
        {
            var data = await _context.AccountTypes
                .Where(at => at.Status == "Active")
                .Include(at => at.Accounts)
                .ThenInclude(a => a.EntryDetails)
                .Where(at => at.Accounts.Any(a => a.Status == "Active"))
                .Select(at => new BalanceSheetReportDTO
                {
                    AccountTypeName = at.Name,
                    Accounts = at.Accounts
                        .Where(a => a.Status == "Active")
                        .Select(a => new AccountReportDTO
                        {
                            AccountName = a.Name,
                            TotalDebit = a.EntryDetails.Sum(ed => ed.DebitAmount ?? 0),
                            TotalCredit = a.EntryDetails.Sum(ed => ed.CreditAmount ?? 0)
                        })
                        .ToList()
                })
                .ToListAsync();

            return data;
        }
    }
}
