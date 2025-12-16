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

        builder.Property(p => p.Name).IsRequired();

        builder.Property(p => p.Price).HasColumnType("decimal(18,2)").IsRequired();

        builder.Property(p => p.Description);

        builder.Property(p => p.ImageUrl);

        builder.Ignore(p => p.DomainEvents);

        builder.HasData(new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Cafe Đen Đá",
                Price = 15000m,
                Description = "Cà phê Robusta đậm đà truyền thống",
                ImageUrl = "https://images.unsplash.com/photo-1559496417-e7f25cb247f3?w=500&q=80",
                CreatedAt = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero)
            },
            new Product
            {
                Id = 2,
                Name = "Cafe Sữa Đá",
                Price = 20000m,
                Description = "Sự hòa quyện giữa cafe đậm và sữa đặc",
                ImageUrl = "https://images.unsplash.com/photo-1572286258217-202dbc1b581e?w=500&q=80",
                CreatedAt = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero)
            },
            new Product
            {
                Id = 3,
                Name = "Bạc Xỉu",
                Price = 25000m,
                Description = "Nhiều sữa ít cafe, vị ngọt dễ uống",
                ImageUrl = "https://images.unsplash.com/photo-1582239682137-97d8b5986871?w=500&q=80",
                CreatedAt = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero)
            },
            new Product
            {
                Id = 4,
                Name = "Trà Đào Cam Sả",
                Price = 35000m,
                Description = "Mát lạnh với miếng đào giòn tan",
                ImageUrl = "https://images.unsplash.com/photo-1595981267035-7b04ca84a82d?w=500&q=80",
                CreatedAt = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero)
            },
            new Product
            {
                Id = 5,
                Name = "Trà Vải Hoa Hồng",
                Price = 35000m,
                Description = "Hương hoa hồng thơm nhẹ kết hợp vải thiều",
                ImageUrl = "https://images.unsplash.com/photo-1621539207019-947702657e3f?w=500&q=80",
                CreatedAt = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero)
            },
            new Product
            {
                Id = 6,
                Name = "Bánh Croissant",
                Price = 28000m,
                Description = "Bánh sừng bò ngàn lớp thơm bơ",
                ImageUrl = "https://images.unsplash.com/photo-1555507036-ab1f4038808a?w=500&q=80",
                CreatedAt = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero)
            },
            new Product
            {
                Id = 7,
                Name = "Tiramisu",
                Price = 40000m,
                Description = "Bánh vị cafe và rượu rum",
                ImageUrl = "https://images.unsplash.com/photo-1571115177098-24ec42ed204d?w=500&q=80",
                CreatedAt = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero)
            }
        });
    }
}
