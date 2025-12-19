using OmniPos.Domain.Common.Events;

namespace OmniPos.Domain.Events.Order;

public class OrderItemAddedEvent : IDomainEvent
{
    public int ProductId { get; private set; }
    public int Quantity { get; private set; }
    public DateTimeOffset OccurredAt { get; private set; }

    public OrderItemAddedEvent(int productId, int quantity, DateTimeOffset? occurredAt = null)
    {
        ProductId = productId;
        Quantity = quantity;
        OccurredAt = occurredAt ?? DateTimeOffset.UtcNow;
    }

}
