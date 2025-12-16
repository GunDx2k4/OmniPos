using OmniPos.Domain.Common;
using OmniPos.Domain.Common.Entities;
using OmniPos.Domain.Events.Product;

namespace OmniPos.Domain.Entities;

public class Product : AuditableEntity, IArchivable
{
    private string _name = string.Empty;
    public string Name
    {
        get { return _name; } 
        set
        {
            DomainException.ThrowIfNullOrEmpty(value);
            if (_name != value)
                _name = value;
        }
    }

    private string? _description = null;
    public string? Description
    {
        get { return _description; }
        set
        {
            DomainException.ThrowIfNullOrEmpty(value);
            if (_description != value)
                _description = value;
        }
    }

    private decimal _price = 0m;
    public decimal Price
    {
        get { return _price; }
        set
        {
            DomainException.ThrowIfNegative(value);
            if (_price != value)
                _price = value;
        }
    }

    private int _stockQuantity = 0;
    public int StockQuantity
    {
        get { return _stockQuantity; }
        set
        {
            DomainException.ThrowIfNegative(value);
            if (_stockQuantity != value)
                _stockQuantity = value;
        }
    }

    private string _imageUrl = "https://cdn-icons-png.flaticon.com/512/4904/4904233.png";
    public string ImageUrl
    {
        get { return _imageUrl; }
        set
        {
            DomainException.ThrowIfNullOrEmpty(value);
            if (_imageUrl != value)
                _imageUrl = value;
        }
    }

    public bool IsArchived { get; set; }
    public DateTimeOffset? ArchivedAt { get; set; }

    public void UpdateDetails(string name, decimal price, string? description = "", string imageUrl = "https://cdn-icons-png.flaticon.com/512/4904/4904233.png")
    {
        DomainException.ThrowIfNullOrEmpty(name);
        DomainException.ThrowIfNullOrEmpty(imageUrl);
        DomainException.ThrowIfNegative(price);
        Name = name;
        Description = description;
        Price = price;
        ImageUrl = imageUrl;
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
