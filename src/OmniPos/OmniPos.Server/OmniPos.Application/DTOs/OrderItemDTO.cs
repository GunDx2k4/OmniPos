namespace OmniPos.Application.DTOs;

public record OrderItemDTO
{
    public int Id { get; init; }
    public int ProductId { get; init; }
    public int Quantity { get; init; }
    public decimal UnitPrice { get; init; }
    public string? Note { get; init; }
}
