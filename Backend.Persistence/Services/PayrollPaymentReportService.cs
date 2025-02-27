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
    public class PayrollPaymentReportService : IReportService<PayrollPaymentReportDTO>
    {
        private readonly DataContext _context;

        public PayrollPaymentReportService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<PayrollPaymentReportDTO>> GenerateGroupedReportAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.PayrollHeaders
                .Include(ph => ph.Worker)
                .Include(ph => ph.PayrollDetails)
                .AsQueryable();

            if (startDate.HasValue)
            {
                query = query.Where(ph => ph.DatePayroll >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(ph => ph.DatePayroll <= endDate.Value);
            }

            var report = await query
                .Select(ph => new PayrollPaymentReportDTO
                {
                    WorkerName = ph.Worker.Name,
                    TotalAmount = ph.PayrollDetails.Sum(pd => pd.Price)
                })
                .ToListAsync();

            return report;
        }
    }
}
