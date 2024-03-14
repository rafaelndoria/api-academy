using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.Infra.Data.Configurations
{
    public class PlanTimeConfiguration : IEntityTypeConfiguration<PlanTime>
    {
        public void Configure(EntityTypeBuilder<PlanTime> builder)
        {
            builder.ToTable("PlanTime");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.StartTime)
                .IsRequired();

            builder.Property(x => x.EndTime)
                .IsRequired();

            builder.Property(x => x.DayWeek)
                .IsRequired();

            builder.Property(x => x.PlayId)
                .IsRequired();

            builder.HasOne(x => x.Plan)
                .WithMany(x => x.PlanTimes)
                .HasForeignKey(x => x.PlayId);
        }
    }
}
