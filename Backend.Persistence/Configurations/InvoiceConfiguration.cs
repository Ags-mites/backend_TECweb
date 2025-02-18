using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistence.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.Details)
                   .WithOne(ed => ed.Invoice)
                   .HasForeignKey(ed => ed.InvoiceId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
