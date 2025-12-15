using OmniPos.Domain.Common;
using OmniPos.Domain.Common.Entities;
using OmniPos.Domain.Events.Product;

namespace OmniPos.Domain.Entities;

public class Product : AuditableEntity
{
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public int StockQuantity { get; private set; }

    protected Product() { }

    public Product(string name, decimal price, int stockQuantity, string? description = null)
    {
        DomainException.ThrowIfNullOrEmpty(name);
        DomainException.ThrowIfNegative(price);
        DomainException.ThrowIfNegative(stockQuantity);
        Name = name;
        Description = description;
        Price = price;
        StockQuantity = stockQuantity;
    }

    public void UpdateDetails(string name, decimal price, string? description = null)
    {
        DomainException.ThrowIfNullOrEmpty(name);
        DomainException.ThrowIfNegative(price);
        Name = name;
        Description = description;
        Price = price;
    }

    public void IncreaseStock(int quantity)
    {
        DomainException.ThrowIfNegative(quantity);
        StockQuantity += quantity;
    }

    public void DecreaseStock(int quantity)
    {
        DomainException.ThrowIfNegative(quantity);

        if (quantity > StockQuantity)
        {
            throw new DomainException("Insufficient stock to decrease by the specified quantity.");
        }
        StockQuantity -= quantity;

        if (StockQuantity == 0)
        {
            AddDomainEvent(new ProductOutOfStockEvent(Id));
        }
    }
}
