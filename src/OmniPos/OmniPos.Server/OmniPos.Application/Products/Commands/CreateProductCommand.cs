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
    private readonly IProductRepository _productRepository = productRepository;

    public async Task HandleAsync(CreateProductCommand command, CancellationToken cancellationToken)
    {
        if (await _productRepository.ProductNameUniqueAsync(command.Name) is not null)
        {
            throw new ApplicationException($"A product with the name '{command.Name}' already exists.");
        }

        var product = new Product(command.Name, command.Price, command.StockQuantity, command.Description);

        await _productRepository.AddAsync(product);
        await _productRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}
