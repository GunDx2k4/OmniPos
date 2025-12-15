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
        var handlerTypes = assembly.GetTypes().Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>))).ToList();

        foreach (var handlerType in handlerTypes)
        {
            _eventHandlers.Add(handlerType);
        }

        _eventHandlers.AddRange(handlerTypes);
    }

    public async Task DispatchAsync<TEvent>(TEvent domainEvent, CancellationToken cancellationToken = default) where TEvent : IDomainEvent
    {
        var handlerInterfaceType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
        var handlers = _eventHandlers
            .Where(t => handlerInterfaceType.IsAssignableFrom(t))
            .Select(t => _serviceProvider.GetService(t))
            .Where(h => h != null)
            .ToList();
        foreach (var handler in handlers)
        {
            if (handler is IDomainEventHandler<TEvent> typedHandler)
            {
                await typedHandler.HandleAsync(domainEvent, cancellationToken);
            }
        }
    }

    public async Task DispatchAsync(ICommand command, CancellationToken cancellationToken = default)
    {
        Type type = typeof(ICommandHandler<>);
        Type[] typeArgs = { command.GetType() };
        Type handlerType = type.MakeGenericType(typeArgs);

        dynamic handler = _serviceProvider.GetService(handlerType);
        await handler.HandleAsync((dynamic)command, cancellationToken);
    }

    public async Task<T> DispatchAsync<T>(IQuery<T> query, CancellationToken cancellationToken = default)
    {
        Type type = typeof(IQueryHandler<,>);
        Type[] typeArgs = { query.GetType(), typeof(T) };
        Type handlerType = type.MakeGenericType(typeArgs);

        dynamic handler = _serviceProvider.GetService(handlerType);
        Task<T> result = handler.HandleAsync((dynamic)query, cancellationToken);
        return await result;
    }
}
