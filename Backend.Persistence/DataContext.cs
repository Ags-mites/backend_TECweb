using Microsoft.EntityFrameworkCore;
using Backend.Entities;
namespace Backend.Persistence
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):
        base(options)
        {
            
        }
        public DbSet<Account> Account { get; set; }
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<Movement> Movement { get; set; }
        public DbSet<PayrollDetail> PayrollDetail { get; set; }
        public DbSet<PayrollHeader> PayrollHeader { get; set; }
        public DbSet<Reasons> Reason { get; set; }
        public DbSet<Voucher> Voucher { get; set; }
        public DbSet<VoucherType> VoucherType { get; set; }
        public DbSet<Workers> Workers { get; set; }
        public DbSet<AuditAM> AuditAM { get; set; }
        public DbSet<MR_ACTIVIDAD> MR_ACTIVIDAD { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        //  protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<FacturacionCliente>().HasNoKey();
        // }
    }
}