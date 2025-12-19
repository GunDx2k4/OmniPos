using OmniPos.Domain.Common;
using OmniPos.Domain.Common.Entities;
using OmniPos.Domain.Enums;
using OmniPos.Domain.Events.Order;
using OmniPos.Domain.Events.Product;

namespace OmniPos.Domain.Entities;

public class Order : AuditableEntity
{
    private StatusOrder _status = StatusOrder.Pending;
    public StatusOrder Status
    {
        get { return _status; }
        set
        {
            if (!Enum.IsDefined(typeof(StatusOrder), value))
            {
                throw new DomainException("Invalid status value.");
            }
            _status = value;
        }
    }

    private decimal _totalAmount = 0m;
    public decimal TotalAmount
    {
        get { return _totalAmount; }
        set
        {
            DomainException.ThrowIfNegative(value);
            _totalAmount = value;
        }
    }

    private PaymentMethod _paymentMethod = PaymentMethod.Cash;
    public PaymentMethod PaymentMethod
    {
        get { return _paymentMethod; }
        set
        {
            if (!Enum.IsDefined(typeof(PaymentMethod), value))
            {
                throw new DomainException("Invalid payment method value.");
            }
            _paymentMethod = value;
        }
    }

    private readonly List<OrderItem> _orderItems = new();

    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

    public void AddOrderItem(Product product, int quantity, string? note = null)
    {
        if (Status != StatusOrder.Pending)
        {
            throw new DomainException("Cannot add items to an order that is not pending.");
        }

        DomainException.ThrowIfNull(product);
        DomainException.ThrowIfNegative(quantity);

        AddDomainEvent(new OrderItemAddedEvent(product.Id, quantity));

        var orderItem = new OrderItem
        {
            ProductId = product.Id,
            ProductName = product.Name,
            UnitPrice = product.Price,
            Quantity = quantity,
            Note = note
        };
        _orderItems.Add(orderItem);
        TotalAmount += orderItem.UnitPrice * orderItem.Quantity;
    }
}
