using Microsoft.EntityFrameworkCore;
using Backend.Entities;

namespace Backend.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<PayrollDetail> PayrollDetails { get; set; }
        public DbSet<PayrollHeader> PayrollHeaders { get; set; }
        public DbSet<Reasons> Reasons { get; set; }
        public DbSet<Workers> Workers { get; set; }
        public DbSet<EntryHeader> EntryHeaders { get; set; }
        public DbSet<EntryDetail> EntryDetails { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Id).ValueGeneratedOnAdd();

                entity.Property(a => a.Code)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(a => a.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(a => a.Status)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(a => a.CreatedAt)
                      .IsRequired();

                entity.HasOne(a => a.AccountType)
                      .WithMany(at => at.Accounts)
                      .HasForeignKey(a => a.AccountTypeId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Relación EntryHeader -> EntryDetail (1:N)
            modelBuilder.Entity<EntryHeader>()
                .HasMany(eh => eh.EntryDetails)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            // Relación EntryDetail -> Account (N:1)
            modelBuilder.Entity<EntryDetail>()
                .HasOne(ed => ed.Account)
                .WithMany()
                .HasForeignKey(ed => ed.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
