using DDD.Domain.Models.Order.ValueObjects;
using DDD.Domain.Models.Product.ValueObjects;

namespace DDD.Domain.Models.Order.Entites;

public class LineItem
{
    public OrderId OrderId { get; private set; } = null!;
    public Aggregate.Order Order { get; private set; }
    public ProductId ProductId { get; private set; } = null!;
    public Product.Aggregate.Product Product { get; private set; }
    public LineItemProductCount Count { get;private set; }
    private LineItem()
    {
        
    }

    private LineItem(OrderId orderId,ProductId productId,LineItemProductCount count)
    {
        OrderId = orderId;
        ProductId = productId;
        Count = count;
    }

    public static LineItem Create(OrderId orderId,ProductId productId,LineItemProductCount count)
    {
        return new LineItem(orderId, productId,count);
    }
}