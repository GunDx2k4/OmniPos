using OmniPos.Application.Common;
using OmniPos.Application.Common.Commands;
using OmniPos.Domain.Repositories;

namespace OmniPos.Application.Products.Commands
{
    public record DeleteProductCommand : ICommand
    {
        public int ProductId { get; init; }
    }

    public class DeleteProductCommandHandler(IProductRepository productRepository) : ICommandHandler<DeleteProductCommand>
    {
        public async Task HandleAsync(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await productRepository.FirstOrDefaultAsync(productRepository.GetQueryableSet().Where(p => p.Id == command.ProductId));

            ApplicationExeption.ThrowIfEntityNotFound(product);

            await productRepository.DeleteAsync(product!);
            await productRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
