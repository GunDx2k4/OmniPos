using OmniPos.Domain.Common.Repositories;
using OmniPos.Domain.Entities;

namespace OmniPos.Domain.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<Product?> ProductNameUniqueAsync(string name, int? excludingProductId = null);
}
