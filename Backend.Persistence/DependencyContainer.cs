using  Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Backend.Persistence.Interfaces;
using Backend.Persistence.Repositories;
using System.Reflection.Metadata.Ecma335;

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
        ){
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountTypeRepository, AccountTypeRepository>();
            services.AddScoped<IMovementRepository, MovementRepository>();
            services.AddScoped<IPayrollDetailRepository, PayrollDetailRepository>();
            services.AddScoped<IPayrollHeaderRepository, PayrollHeaderRepository>();
            services.AddScoped<IReasonRepository, ReasonRepository>();
            services.AddScoped<IVoucherRespository, VoucherRespository>();
            services.AddScoped<IVoucherTypeRepository, VoucherTypeRepository>();
            services.AddScoped<IWorkersRepository, WorkersRepository>();
            services.AddScoped<IClientsFacRepository, ClientsFacRepository>();
            services.AddScoped<ICiudadEntrFacRepository, CiudadEntrFacRepository>();
            services.AddScoped<IFacturacionClienteRepository, FacturacionClienteRepository>();
            services.AddScoped<IAuditAMRepository, AuditRepository>();
            services.AddScoped<IMR_ACTIVIDADRepository, MR_ACTIVIDADRepository>();
            return services;
        }
    }
}