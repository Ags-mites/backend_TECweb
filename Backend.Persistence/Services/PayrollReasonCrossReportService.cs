using Backend.Persistence.Interfaces;
using Backend.DTOs.PayrollReport;
using Backend.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Persistence.Services
{
    public class PayrollReasonCrossReportService : IReportService<PayrollReasonCrossReportDTO>
    {
        private readonly DataContext _context;

        public PayrollReasonCrossReportService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<PayrollReasonCrossReportDTO>> GenerateGroupedReportAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.PayrollHeaders
                .Include(ph => ph.Worker)
                .Include(ph => ph.PayrollDetails)
                .ThenInclude(pd => pd.Reason)
                .AsQueryable();

            if (startDate.HasValue)
            {
                query = query.Where(ph => ph.DatePayroll >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(ph => ph.DatePayroll <= endDate.Value);
            }

            var payrolls = await query.ToListAsync();

            var report = payrolls.GroupBy(ph => ph.Worker.Name)
                .Select(group => new PayrollReasonCrossReportDTO
                {
                    WorkerName = group.Key,
                    ReasonAmounts = group.SelectMany(ph => ph.PayrollDetails)
                        .GroupBy(pd => pd.Reason.Name)
                        .ToDictionary(rg => rg.Key, rg => rg.Sum(pd => pd.Price))
                }).ToList();

            return report;
        }
    }
}
