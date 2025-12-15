using OmniPos.Domain.Common.Repositories;

namespace OmniPos.Application.Common.Commands;

public interface ICommandHandler<TCommand> where TCommand : ICommand
{
    Task HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}
