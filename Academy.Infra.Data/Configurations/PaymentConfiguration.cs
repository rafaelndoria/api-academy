using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.Infra.Data.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payment");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DatePayment)
                .IsRequired();

            builder.Property(x => x.Value)
                .IsRequired()
                .HasPrecision(12, 2);

            builder.Property(x => x.TypePaymentId)
                .IsRequired();

            builder.HasOne(x => x.TypePayment)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.TypePaymentId);
        }
    }
}
