using Microsoft.Extensions.DependencyInjection;
using OmniPos.Application.Common;
using OmniPos.Application.Common.Commands;
using OmniPos.Application.Common.Queries;
using OmniPos.Application.DTOs;
using OmniPos.Application.Orders.Commands;
using OmniPos.Application.Orders.Queries;
using OmniPos.Application.Products.Commands;
using OmniPos.Application.Products.Queries;
using System.Reflection;

namespace OmniPos.Application;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<CreateProductCommand>, CreateProductCommandHandler>();
        services.AddScoped<ICommandHandler<DeleteProductCommand>, DeleteProductCommandHandler>();
        services.AddScoped<IQueryHandler<GetProductQuery, ProductDTO>, GetProductQueryHandler>();
        services.AddScoped<IQueryHandler<GetProductsQuery, IEnumerable<ProductDTO>>, GetProductsQueryHandler>();
        services.AddScoped<ICommandHandler<CreateOrderCommand, int>, CreateOrderCommandHandler>();
        services.AddScoped<IQueryHandler<GetOrderQuery, OrderDTO>, GetOrderQueryHandler>();

        return services;
    }

    public static IServiceCollection AddMessageHandlers(this IServiceCollection services)
    {
        services.AddScoped<Dispatcher>();

        var assembly = Assembly.GetExecutingAssembly();

        Dispatcher.RegisterEventHandlers(assembly, services);
        return services;
    }
}
