using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniPos.Domain.Entities;

namespace OmniPos.Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).ValueGeneratedOnAdd();

        builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
        
        builder.Ignore(p => p.DomainEvents);

        builder.HasData(new List<Product>
        {
            new ("Cappuccino", 3.50m, 5, "A classic Italian coffee drink made with espresso, steamed milk, and milk foam.") { Id = 1, CreatedAt = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero) },
            new ("Latte", 4.00m, 8, "A creamy coffee drink made with espresso and steamed milk, topped with a small amount of milk foam.") { Id = 2, CreatedAt = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero) },
            new ("Espresso", 2.50m, 10, "A strong and concentrated coffee made by forcing hot water through finely-ground coffee beans.") { Id = 3, CreatedAt = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero) },
        });
    }
}
