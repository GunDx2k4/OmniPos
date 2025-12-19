using OmniPos.Domain.Common.Events;
using OmniPos.Domain.Events.Order;
using OmniPos.Domain.Repositories;

namespace OmniPos.Application.Orders.EventHandlers
{
    public class OrderItemAddedEventHandler(IProductRepository productRepository) : IDomainEventHandler<OrderItemAddedEvent>
    {
        public async Task HandleAsync(OrderItemAddedEvent domainEvent, CancellationToken cancellationToken = default)
        {
            var product = await productRepository.FirstOrDefaultAsync(productRepository.GetQueryableSet().Where(p => p.Id == domainEvent.ProductId));
            if (product == null) return;
            product.DecreaseStock(domainEvent.Quantity);
            await productRepository.UpdateAsync(product, cancellationToken);
        }
    }
}
