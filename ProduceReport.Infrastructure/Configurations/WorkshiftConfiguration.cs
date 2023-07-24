
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProduceReport.Core;

namespace ProduceReport.Infrastructure.Configurations
{
    internal class WorkshiftConfiguration : IEntityTypeConfiguration<Workshift>
    {
        public void Configure(EntityTypeBuilder<Workshift> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id)
                .IsUnique();

            builder.Property(x => x.ProduceQuantity)
                .IsRequired();

            builder.HasOne(x => x.Workshop)
                .WithMany(w => w.Workshifts)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
