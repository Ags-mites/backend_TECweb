using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Backend.Persistence.Interfaces;
using Backend.Persistence.Repositories;
using Backend.Persistence.Services;
using System.Reflection.Metadata.Ecma335;
using Backend.DTOs.AccountReports;
using Backend.DTOs.PayrollReport;

namespace Backend.Persistence
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddContextSqlServer(
            this IServiceCollection services,
            IConfiguration configuration,
            string connectionString
        )
        {
            services.AddSqlServer<DataContext>(configuration.GetConnectionString(connectionString));
            return services;
        }

        public static IServiceCollection AddRepositories(
            this IServiceCollection services
        )
        {
            services.AddScoped<IReportService<BalanceSheetReportDTO>, BalanceSheetReportService>();
            services.AddScoped<IReportService<IncomeStatementReportDTO>, IncomeStatementReportService>();
            services.AddScoped<IReportService<PayrollPaymentReportDTO>, PayrollPaymentReportService>();
            services.AddScoped<IReportService<PayrollReasonCrossReportDTO>, PayrollReasonCrossReportService>();
            

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountTypeRepository, AccountTypeRepository>();
            services.AddScoped<IPayrollDetailRepository, PayrollDetailRepository>();
            services.AddScoped<IPayrollHeaderRepository, PayrollHeaderRepository>();
            services.AddScoped<IEntryHeaderRepository, EntryHeaderRepository>();
            services.AddScoped<IEntryDetailRepository, EntryDetailRepository>();
            services.AddScoped<IReasonRepository, ReasonRepository>();
            services.AddScoped<IWorkersRepository, WorkersRepository>();
            services.AddScoped<ICitiesRepository, CitiesRepository>();
            services.AddScoped<IClientsRepository, ClientsRepository>();
            services.AddScoped<IInvoiceDetailRepository, InvoiceDetailRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            return services;
        }
    }
}