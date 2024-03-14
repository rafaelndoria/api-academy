using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.Infra.Data.Configurations
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable("Subscription");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DateSubscription)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.AccessPermittedUntil);

            builder.Property(x => x.CustomerId)
                .IsRequired();

            builder.Property(x => x.PlanId)
                .IsRequired();

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Subscriptions)
                .HasForeignKey(x => x.CustomerId);

            builder.HasOne(x => x.Plan)
                .WithMany(x => x.Subscriptions)
                .HasForeignKey(x => x.PlanId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
