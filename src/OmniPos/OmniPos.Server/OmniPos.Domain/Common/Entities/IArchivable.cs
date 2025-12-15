namespace OmniPos.Domain.Common.Entities;

public interface IArchivable
{
    bool IsArchived { get; set; }
    DateTimeOffset? ArchivedAt { get; set; }
}
