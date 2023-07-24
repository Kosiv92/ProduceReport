using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProduceReport.Core;

namespace ProduceReport.Infrastructure.Configurations
{
    internal class WorkshopConfiguration : IEntityTypeConfiguration<Workshop>
    {
        public void Configure(EntityTypeBuilder<Workshop> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id)
                .IsUnique();

            builder.Property(x => x.Name)
                .HasMaxLength(40)
                .IsRequired();

            builder.HasMany(x => x.Workshifts)
                .WithOne(w => w.Workshop)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
