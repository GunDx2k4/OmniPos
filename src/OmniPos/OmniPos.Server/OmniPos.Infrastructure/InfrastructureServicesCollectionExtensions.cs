using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OmniPos.Domain.Repositories;
using OmniPos.Infrastructure.Persistence.Common;
using OmniPos.Infrastructure.Persistence.Repositories;

namespace OmniPos.Infrastructure;

public static class InfrastructureServicesCollectionExtensions
{
    public static IServiceCollection AddPrersistence(this IServiceCollection services, string connectionString, int? commandTimeout = null)
    {
        services.AddDbContext<OmniPosDbContext>(options => options.UseSqlServer(connectionString, sql =>
        {
            if (commandTimeout.HasValue)
            {
                sql.CommandTimeout(commandTimeout.Value);
            }
        })).AddRepositories();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}
