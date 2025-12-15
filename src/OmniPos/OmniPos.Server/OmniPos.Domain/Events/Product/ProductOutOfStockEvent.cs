using OmniPos.Domain.Common.Events;

namespace OmniPos.Domain.Events.Product;

public record ProductOutOfStockEvent : IDomainEvent
{
    public int ProductId { get; private set; }
    public DateTimeOffset OccurredAt { get; private set; }

    public ProductOutOfStockEvent(int productId, DateTimeOffset? occurredAt = null)
    {
        ProductId = productId;
        OccurredAt = occurredAt ?? DateTimeOffset.UtcNow;
    }
}
