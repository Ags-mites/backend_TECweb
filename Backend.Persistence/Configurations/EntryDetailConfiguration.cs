using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistence.Configurations
{
    public class EntryDetailConfiguration : IEntityTypeConfiguration<EntryDetail>
    {
        public void Configure(EntityTypeBuilder<EntryDetail> builder)
        {
            builder.HasKey(ed => ed.Id);

            builder.Property(ed => ed.Description)
                   .HasMaxLength(255);

            builder.Property(ed => ed.DebitAmount)
                   .HasColumnType("decimal(18,2)");

            builder.Property(ed => ed.CreditAmount)
                   .HasColumnType("decimal(18,2)");
        }
    }
}
