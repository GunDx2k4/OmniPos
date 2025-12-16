namespace OmniPos.Application.DTOs;

public record ProductDTO
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
    public decimal Price { get; init; }
    public int StockQuantity { get; init; }
    public string ImageUrrl { get; init; } = "https://cdn-icons-png.flaticon.com/512/4904/4904233.png";
}
