using Backend.DTOs.AccountReports;
using Backend.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Persistence.Services
{
    public class BalanceSheetReportService : IReportService<BalanceSheetReportDTO>
    {
        private readonly DataContext _context;

        public BalanceSheetReportService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<BalanceSheetReportDTO>> GenerateGroupedReportAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.AccountTypes
                .Where(at => at.Status == "Active")
                .Include(at => at.Accounts)
                .ThenInclude(a => a.EntryDetails)
                    .ThenInclude(ed => ed.EntryHeader) // Se incluye la relación con EntryHeader
                .Where(at => at.Accounts.Any(a => a.Status == "Active"))
                .AsQueryable();

            if (startDate.HasValue)
            {
                query = query.Where(at => at.Accounts
                    .Any(a => a.EntryDetails.Any(ed => ed.EntryHeader.EntryDate >= startDate.Value)));
            }

            if (endDate.HasValue)
            {
                query = query.Where(at => at.Accounts
                    .Any(a => a.EntryDetails.Any(ed => ed.EntryHeader.EntryDate <= endDate.Value)));
            }

            var data = await query
                .Select(at => new BalanceSheetReportDTO
                {
                    AccountTypeName = at.Name,
                    Accounts = at.Accounts
                        .Where(a => a.Status == "Active")
                        .Select(a => new AccountReportDTO
                        {
                            AccountName = a.Name,
                            TotalDebit = a.EntryDetails
                                .Where(ed => (!startDate.HasValue || ed.EntryHeader.EntryDate >= startDate.Value) &&
                                             (!endDate.HasValue || ed.EntryHeader.EntryDate <= endDate.Value))
                                .Sum(ed => ed.DebitAmount ?? 0),
                            TotalCredit = a.EntryDetails
                                .Where(ed => (!startDate.HasValue || ed.EntryHeader.EntryDate >= startDate.Value) &&
                                             (!endDate.HasValue || ed.EntryHeader.EntryDate <= endDate.Value))
                                .Sum(ed => ed.CreditAmount ?? 0)
                        })
                        .ToList()
                })
                .ToListAsync();

            return data;
        }
    }
}
