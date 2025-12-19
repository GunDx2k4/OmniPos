using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniPos.Domain.Entities;

namespace OmniPos.Infrastructure.Persistence.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(oi => oi.Id);
        builder.Property(oi => oi.ProductId)
            .IsRequired();
        builder.Property(oi => oi.ProductName)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(oi => oi.UnitPrice)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        builder.Property(oi => oi.Quantity)
            .IsRequired();
        builder.Property(oi => oi.Note)
            .HasMaxLength(1000);
    }
}
