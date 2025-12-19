using OmniPos.Application.Common.Commands;
using OmniPos.Domain.Entities;
using OmniPos.Domain.Repositories;

namespace OmniPos.Application.Products.Commands;

public record CreateProductCommand : ICommand
{
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
    public int StockQuantity { get; init; }
    public decimal Price { get; init; }
}

public class CreateProductCommandHandler(IProductRepository productRepository) : ICommandHandler<CreateProductCommand>
{
    public async Task HandleAsync(CreateProductCommand command, CancellationToken cancellationToken)
    {
        if (await productRepository.ProductNameUniqueAsync(command.Name) is not null)
        {
            throw new ApplicationException($"A product with the name '{command.Name}' already exists.");
        }

        var product = new Product
        {
            Name = command.Name,
            Description = command.Description,
            StockQuantity = command.StockQuantity,
            Price = command.Price
        };

        await productRepository.AddAsync(product);
        await productRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}
