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
        private readonly IProductRepository _productRepository = productRepository;
        public async Task HandleAsync(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FirstOrDefaultAsync(_productRepository.GetQueryableSet().Where(p => p.Id == command.ProductId));

            ApplicationExeption.ThrowIfEntityNotFound(product);

            await _productRepository.DeleteAsync(product);
            await _productRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
