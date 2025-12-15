namespace OmniPos.Domain.Common.Events;

public interface IDomainEvent
{
    DateTimeOffset OccurredAt { get; }
}
