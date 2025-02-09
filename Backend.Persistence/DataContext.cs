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
        public DbSet<EntryHeader> EntryHeaders { get; set; }
        public DbSet<EntryDetail> EntryDetail { get; set; }
        public DbSet<Workers> Workers { get; set; }
        public DbSet<AuditAM> AuditAM { get; set; }
        public DbSet<MR_ACTIVIDAD> MR_ACTIVIDAD { get; set; }
        public DbSet<ClientsFac> ClientsFac { get; set; }
        public DbSet<CiudadEntrFac> CiudadEntrFac { get; set; }
        public DbSet<FacturacionCliente> FacturacionCliente { get; set; }
        //  protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<FacturacionCliente>().HasNoKey();
        // }
    }
}