using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistence.Configurations
{
    public class PayrollHeaderConfiguration : IEntityTypeConfiguration<PayrollHeader>
    {
        public void Configure(EntityTypeBuilder<PayrollHeader> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(e => e.DatePayroll)
                   .HasConversion(
                       v => v.Date,
                       v => v
                   )
                   .HasColumnType("DATE");
//todo revisar 
            builder.HasMany(e => e.PayrollDetails)
                   .WithOne(ed => ed.PayrollHeader)
                   .HasForeignKey(ed => ed.PayrollHeaderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}