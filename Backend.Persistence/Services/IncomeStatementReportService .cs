using Backend.DTOs.AccountReports;
using Backend.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Persistence.Services
{
    public class IncomeStatementReportService : IIncomeStatementReportRepository
    {
        private readonly DataContext _context;

        public IncomeStatementReportService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<IncomeStatementReportDTO>> GenerateGroupedReportAsync()
        {
            var data = await _context.AccountTypes
                .Where(at => at.Status == "Active")
                .Include(at => at.Accounts)
                .ThenInclude(a => a.EntryDetails)
                .Where(at => at.Accounts.Any(a => a.Status == "Active"))
                .Select(at => new IncomeStatementReportDTO
                {
                    AccountTypeName = at.Name,
                    Accounts = at.Accounts
                        .Where(a => a.Status == "Active")
                        .Select(a => new AccountReportDTO
                        {
                            AccountName = a.Name,
                            TotalDebit = a.EntryDetails
                                .Where(ed => ed.DebitAmount != null)
                                .Sum(ed => ed.DebitAmount ?? 0),
                            TotalCredit = a.EntryDetails
                                .Where(ed => ed.CreditAmount != null)
                                .Sum(ed => ed.CreditAmount ?? 0)
                        })
                        .ToList(),
                    TotalRevenue = at.Accounts
                        .Where(a => a.Status == "Active")
                        .SelectMany(a => a.EntryDetails)
                        .Where(ed => ed.CreditAmount != null)
                        .Sum(ed => ed.CreditAmount ?? 0),
                    TotalExpenses = at.Accounts
                        .Where(a => a.Status == "Active")
                        .SelectMany(a => a.EntryDetails)
                        .Where(ed => ed.DebitAmount != null)
                        .Sum(ed => ed.DebitAmount ?? 0)
                })
                .ToListAsync();

            return data;
        }


    }
}
