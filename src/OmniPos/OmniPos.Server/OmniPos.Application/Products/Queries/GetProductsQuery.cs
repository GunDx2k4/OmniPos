using OmniPos.Application.Common.Queries;
using OmniPos.Application.DTOs;
using OmniPos.Domain.Repositories;

namespace OmniPos.Application.Products.Queries
{
    public record GetProductsQuery : IQuery<IEnumerable<ProductDTO>>
    {
    }

    public class GetProductsQueryHandler(IProductRepository productRepository) : IQueryHandler<GetProductsQuery, IEnumerable<ProductDTO>>
    {
        private readonly IProductRepository _productRepository = productRepository;
        public async Task<IEnumerable<ProductDTO>> HandleAsync(GetProductsQuery query, CancellationToken cancellationToken)
        {
            var queryable = _productRepository.GetQueryableSet()
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity
                });

            var productDTOs = await _productRepository.ToListAsync(queryable);

            return productDTOs;
        }
    }
}
