using OmniPos.Application.Common;
using OmniPos.Application.Common.Queries;
using OmniPos.Application.DTOs;
using OmniPos.Domain.Repositories;

namespace OmniPos.Application.Products.Queries;

public record GetProductQuery : IQuery<ProductDTO>
{
    public int ProductId { get; init; }
}

public class GetProductQueryHandler(IProductRepository productRepository) : IQueryHandler<GetProductQuery, ProductDTO>
{
    public async Task<ProductDTO> HandleAsync(GetProductQuery query, CancellationToken cancellationToken)
    {
        var queryable = productRepository.GetQueryableSet()
            .Where(p => p.Id == query.ProductId)
            .Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity
            });

        var productDto = await productRepository.FirstOrDefaultAsync(queryable);

        ApplicationExeption.ThrowIfEntityNotFound(productDto);

        return productDto!;
    }
}
