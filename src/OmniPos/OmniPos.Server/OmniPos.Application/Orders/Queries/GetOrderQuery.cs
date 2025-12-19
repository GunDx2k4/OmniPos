using OmniPos.Application.Common;
using OmniPos.Application.Common.Queries;
using OmniPos.Application.DTOs;
using OmniPos.Domain.Repositories;

namespace OmniPos.Application.Orders.Queries;

public record GetOrderQuery : IQuery<OrderDTO>
{
    public int OrderId { get; init; }
}

public class GetOrderQueryHandler(IOrderRepository orderRepository) : IQueryHandler<GetOrderQuery, OrderDTO>
{
    public async Task<OrderDTO> HandleAsync(GetOrderQuery query, CancellationToken cancellationToken)
    {
        var queryable = orderRepository.GetQueryableSet()
            .Where(o => o.Id == query.OrderId)
            .Select(o => new OrderDTO
            {
                Id = o.Id,
                TotalAmount = o.TotalAmount,
                PaymentMethod = o.PaymentMethod,
                OrderItems = o.OrderItems.Select(i => new OrderItemDTO
                {
                    Id = i.Id,
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    Note = i.Note,
                }).ToList(),
                CreatedAt = o.CreatedAt,
            });
        var orderDto = await orderRepository.FirstOrDefaultAsync(queryable);
        ApplicationExeption.ThrowIfEntityNotFound(orderDto);
        return orderDto!;
    }
}
