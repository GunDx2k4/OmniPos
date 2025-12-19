using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniPos.Domain.Entities;

namespace OmniPos.Infrastructure.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.CreatedAt)
            .IsRequired();
        builder.Property(o => o.Status)
            .IsRequired();
        builder.Property(o => o.PaymentMethod)
            .IsRequired();
        builder.Property(o => o.TotalAmount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        builder.HasMany(o => o.OrderItems)
            .WithOne()
            .HasForeignKey(oi => oi.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
