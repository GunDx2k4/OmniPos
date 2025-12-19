using OmniPos.Application.Common.Commands;
using OmniPos.Application.DTOs;
using OmniPos.Domain.Entities;
using OmniPos.Domain.Enums;
using OmniPos.Domain.Repositories;

namespace OmniPos.Application.Orders.Commands;

public record CreateOrderCommand : ICommand<int>
{
    public List<OrderItemDTO> Items { get; init; } = new();
    public PaymentMethod PaymentMethod { get; init; }
}

public class CreateOrderCommandHandler(IProductRepository productRepository, IOrderRepository orderRepository) : ICommandHandler<CreateOrderCommand, int>
{

    public async Task<int> HandleAsync(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            PaymentMethod = command.PaymentMethod,
        };

        foreach (var item in command.Items)
        {
            var product = await productRepository.FirstOrDefaultAsync(productRepository.GetQueryableSet().Where(p => p.Id == item.ProductId));
            if (product == null) return -1;


            order.AddOrderItem(product, item.Quantity, item.Note);
        }

        await orderRepository.AddAsync(order, cancellationToken);
        await orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);



        return order.Id;
    }
}
