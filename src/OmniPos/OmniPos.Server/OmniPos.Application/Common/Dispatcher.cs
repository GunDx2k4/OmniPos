using Microsoft.Extensions.DependencyInjection;
using OmniPos.Application.Common.Commands;
using OmniPos.Application.Common.Queries;
using OmniPos.Domain.Common.Events;
using System.Reflection;

namespace OmniPos.Application.Common;

public class Dispatcher(IServiceProvider serviceProvider)
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    private static List<Type> _eventHandlers = new List<Type>();

    public static void RegisterEventHandlers(Assembly assembly, IServiceCollection services)
    {
        var handlerTypes = assembly.GetTypes().Where(t => t.GetInterfaces().Any(i => i.IsGenericType && (i.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>)))).ToList();

        foreach (var handlerType in handlerTypes)
        {
            services.AddTransient(handlerType);
        }

        _eventHandlers.AddRange(handlerTypes);
    }

    public async Task DispatchAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        foreach (Type handlerType in _eventHandlers)
        {
            bool canHandleEvent = handlerType.GetInterfaces()
                .Any(x => x.IsGenericType
                    && x.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>)
                    && x.GenericTypeArguments[0] == domainEvent.GetType());

            if (canHandleEvent)
            {
                dynamic handler = _serviceProvider.GetService(handlerType)!;
                if (handler == null)
                    throw new Exception($"Domain Event Handler for {domainEvent.GetType().Name} not found!");
                await handler.HandleAsync((dynamic)domainEvent, cancellationToken);
            }
        }
    }

    public async Task DispatchAsync(ICommand command, CancellationToken cancellationToken = default)
    {
        Type type = typeof(ICommandHandler<>);
        Type[] typeArgs = { command.GetType() };
        Type handlerType = type.MakeGenericType(typeArgs);

        dynamic handler = _serviceProvider.GetService(handlerType)!;
        if (handler == null)
            throw new Exception($"Command Handler for {command.GetType().Name} not found!");
        await handler.HandleAsync((dynamic)command, cancellationToken);
    }

    public async Task<T> DispatchAsync<T>(ICommand<T> command, CancellationToken cancellationToken = default)
    {
        Type type = typeof(ICommandHandler<,>);
        Type[] typeArgs = { command.GetType(), typeof(T) };
        Type handlerType = type.MakeGenericType(typeArgs);
        dynamic handler = _serviceProvider.GetService(handlerType)!;
        if (handler == null)
            throw new Exception($"Command Handler for {command.GetType().Name} not found!");
        Task<T> result = handler.HandleAsync((dynamic)command, cancellationToken);
        return await result;
    }

    public async Task<T> DispatchAsync<T>(IQuery<T> query, CancellationToken cancellationToken = default)
    {
        Type type = typeof(IQueryHandler<,>);
        Type[] typeArgs = { query.GetType(), typeof(T) };
        Type handlerType = type.MakeGenericType(typeArgs);

        dynamic handler = _serviceProvider.GetService(handlerType)!;
        if (handler == null)
            throw new Exception($"Query Handler for {query.GetType().Name} not found!");
        Task<T> result = handler.HandleAsync((dynamic)query, cancellationToken);
        return await result;
    }
}
