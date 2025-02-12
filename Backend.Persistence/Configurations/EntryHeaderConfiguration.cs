using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistence.Configurations
{
    public class EntryHeaderConfiguration : IEntityTypeConfiguration<EntryHeader>
    {
        public void Configure(EntityTypeBuilder<EntryHeader> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Numeration)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasMany(e => e.EntryDetails)
                   .WithOne(ed => ed.EntryHeader)
                   .HasForeignKey(ed => ed.EntryHeaderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
