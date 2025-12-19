using OmniPos.Domain.Common;

namespace OmniPos.Domain.Exceptions;

public class OutOfStockException(int productId, string productName, int available, int requested) : DomainException($"Insufficient stock for product {productName}. Requested: {requested}, Available: {available}")
{
    public int ProductId { get; }
    public string ProductName { get; } = string.Empty;
    public int Available { get; }
    public int Requested { get; }
}
