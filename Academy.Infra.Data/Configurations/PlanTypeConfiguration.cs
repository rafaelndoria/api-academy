using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.Infra.Data.Configurations
{
    public class PlanTypeConfiguration : IEntityTypeConfiguration<PlanType>
    {
        public void Configure(EntityTypeBuilder<PlanType> builder)
        {
            builder.ToTable("PlanType");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new PlanType(1, "Monthly", 1),
                new PlanType(2, "Bimonthly", 2),
                new PlanType(3, "Semiannual", 6),
                new PlanType(4, "Yearly", 12));
        }
    }
}
