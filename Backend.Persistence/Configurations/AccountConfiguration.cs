using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            /* builder.ToTable("account"); */

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Code)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(a => a.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Status)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.HasOne(a => a.AccountType)
                   .WithMany(at => at.Accounts)
                   .HasForeignKey(a => a.AccountTypeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
