using OmniPos.Domain.Enums;

namespace OmniPos.Server.Models;

public class OrderModel
{
    public int Id { get; set; }
    public StatusOrder Status { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public List<OrderItemModel> Items { get; set; } = new();
}
