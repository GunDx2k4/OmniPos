using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OmniPos.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    ArchivedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ArchivedAt", "CreatedAt", "Description", "ImageUrl", "IsArchived", "LastModifiedAt", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, null, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Cà phê Robusta đậm đà truyền thống", "https://images.unsplash.com/photo-1559496417-e7f25cb247f3?w=500&q=80", false, null, "Cafe Đen Đá", 15000m, 0 },
                    { 2, null, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Sự hòa quyện giữa cafe đậm và sữa đặc", "https://images.unsplash.com/photo-1572286258217-202dbc1b581e?w=500&q=80", false, null, "Cafe Sữa Đá", 20000m, 0 },
                    { 3, null, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Nhiều sữa ít cafe, vị ngọt dễ uống", "https://images.unsplash.com/photo-1582239682137-97d8b5986871?w=500&q=80", false, null, "Bạc Xỉu", 25000m, 0 },
                    { 4, null, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Mát lạnh với miếng đào giòn tan", "https://images.unsplash.com/photo-1595981267035-7b04ca84a82d?w=500&q=80", false, null, "Trà Đào Cam Sả", 35000m, 0 },
                    { 5, null, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hương hoa hồng thơm nhẹ kết hợp vải thiều", "https://images.unsplash.com/photo-1621539207019-947702657e3f?w=500&q=80", false, null, "Trà Vải Hoa Hồng", 35000m, 0 },
                    { 6, null, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Bánh sừng bò ngàn lớp thơm bơ", "https://images.unsplash.com/photo-1555507036-ab1f4038808a?w=500&q=80", false, null, "Bánh Croissant", 28000m, 0 },
                    { 7, null, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Bánh vị cafe và rượu rum", "https://images.unsplash.com/photo-1571115177098-24ec42ed204d?w=500&q=80", false, null, "Tiramisu", 40000m, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
