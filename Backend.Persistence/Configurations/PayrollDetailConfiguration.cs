using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistence.Configurations
{
    public class PayrollDetailConfiguration : IEntityTypeConfiguration<PayrollDetail>
    {
        public void Configure(EntityTypeBuilder<PayrollDetail> builder)
        {
            builder.HasKey(ed => ed.Id);

            builder.Property(ed => ed.Price)
                   .HasColumnType("decimal(18,2)");
        }
    }
}
