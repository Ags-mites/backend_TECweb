using Microsoft.EntityFrameworkCore;
using Backend.Entities;

namespace Backend.Persistence.Data
{
    public partial class AccountDataContext : DbContext
    {
        public AccountDataContext(DbContextOptions<AccountDataContext> options) : base(options) { }

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
        }
    }
}