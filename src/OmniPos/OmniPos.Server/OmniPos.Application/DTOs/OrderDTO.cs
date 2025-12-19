using OmniPos.Domain.Enums;

namespace OmniPos.Application.DTOs;

public record OrderDTO
{
    public int Id { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public StatusOrder Status { get; init; }
    public PaymentMethod PaymentMethod { get; init; }
    public decimal TotalAmount { get; init; }
    public List<OrderItemDTO> OrderItems { get; init; } = new();
}
