using OmniPos.Domain.Common;
using OmniPos.Domain.Common.Entities;

namespace OmniPos.Domain.Entities;

public class OrderItem : AuditableEntity
{
    private int _productId = -1;
    public int ProductId
    {
        get { return _productId; }
        set 
        { 
            if (value <= 0)
            {
                throw new DomainException("ProductId must be a positive integer.");
            }
            _productId = value; 
        }
    }

    private string _productName = string.Empty;

    public string ProductName
    {
        get { return _productName; }
        set
        {
            DomainException.ThrowIfNullOrEmpty(value);
            _productName = value;
        }
    }

    private decimal _unitPrice = 0;
    public decimal UnitPrice
    {
        get { return _unitPrice; }
        set
        {
            DomainException.ThrowIfNegative(value);
            _unitPrice = value;
        }
    }

    private int _quantity = 1;
    public int Quantity
    {
        get { return _quantity; }
        set
        {
            DomainException.ThrowIfNegative(value);
            _quantity = value;
        }
    }

    private string? _note = null;
    public string? Note
    {
        get { return _note; }
        set
        {
            _note = value;
        }
    }
}
