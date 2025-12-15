using Microsoft.Extensions.DependencyInjection;
using OmniPos.Application.Common;
using OmniPos.Application.Common.Commands;
using OmniPos.Application.Common.Queries;
using OmniPos.Application.DTOs;
using OmniPos.Application.Products.Commands;
using OmniPos.Application.Products.Queries;

namespace OmniPos.Application;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<CreateProductCommand>, CreateProductCommandHandler>();
        services.AddScoped<ICommandHandler<DeleteProductCommand>, DeleteProductCommandHandler>();
        services.AddScoped<IQueryHandler<GetProductQuery, ProductDTO>, GetProductQueryHandler>();
        services.AddScoped<IQueryHandler<GetProductsQuery, IEnumerable<ProductDTO>>, GetProductsQueryHandler>();

        return services;
    }

    public static IServiceCollection AddMessageHandlers(this IServiceCollection services)
    {
        services.AddScoped<Dispatcher>();
        return services;
    }
}
