using Microsoft.EntityFrameworkCore;
using Backend.Entities;
using System.Reflection;

namespace Backend.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<PayrollDetail> PayrollDetails { get; set; }
        public DbSet<PayrollHeader> PayrollHeaders { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<EntryHeader> EntryHeaders { get; set; }
        public DbSet<EntryDetail> EntryDetails { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //configuracion temporal
            //todo cambiar ajuste
            modelBuilder.Entity<InvoiceDetail>()
                .Property(i => i.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Worker>()
                .Property(w => w.Salary)
                .HasColumnType("decimal(18,2)");
        }
    }
}
