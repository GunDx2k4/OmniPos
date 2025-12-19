using OmniPos.Domain.Entities;
using OmniPos.Domain.Repositories;
using OmniPos.Infrastructure.Persistence.Common;

namespace OmniPos.Infrastructure.Persistence.Repositories;

public class ProductRepository(OmniPosDbContext dbContext) : Repository<Product>(dbContext), IProductRepository
{
    public async Task<Product?> ProductNameUniqueAsync(string name, int? excludingProductId = null)
    {
        return await FirstOrDefaultAsync(GetQueryableSet().Where(p => p.Name == name && (excludingProductId == null || p.Id != excludingProductId)));
    }

    public async Task<bool> ExistProductAsync(int productId)
    {
        return await FirstOrDefaultAsync(GetQueryableSet().Where(p => p.Id == productId)) is not null;
    }
}
