using DDD.Application.Contracts.Persistence.Repository;
using DDD.Domain.Exceptions;
using DDD.Domain.Models.Order.Entites;
using DDD.Domain.Models.Order.Enums;
using DDD.Domain.Models.Order.ValueObjects;
using DDD.Domain.Models.User.ValueObjects;
using DDD.Domain.Repository;

namespace DDD.Domain.Models.Order.Aggregate;

public class Order
{
    public OrderId OrderId { get; private set; } = null!;
    public OrderPrice Price { get; private set; } = null!;
    private List<LineItem> _items = new List<LineItem>();
    public IReadOnlyList<LineItem> LineItems => _items.ToList();
    public OrderStatus OrderStatus { get; private set; }
    public UserId UserId { get; private set; }
    public User.Aggregate.User User { get; private set; }
    private Order()
    {
        
    }
    
    
    public static async Task<Order> Create(Dictionary<Guid,int> products,Guid userId,IProductRepository productRepository,IUserRepository userRepository)
    {
        var user = await userRepository.GetByCondition(u=>u.UserId==new UserId(userId))
                   ?? throw new UserAssignedToOrderNotFoundException(userId);
        var productIds = products.Select(p => p.Key).ToArray();
        var orderProducts = await productRepository.FetchProductsForOrder(productIds);
        if (orderProducts.Count != productIds.Length)
            throw new PlacedProductsInOrderNotFound();
        var newOrder=new Order()
        {
            OrderId = new OrderId(),
            OrderStatus = OrderStatus.Placed,
            Price = new OrderPrice(orderProducts.Sum(p=>p.Price.Value*products[p.ProductId.Value])),
            User = user
        };
        foreach (var product in orderProducts)
        {
            var productCount = products[product.ProductId.Value];
           product.DecreaseProductInventoryCount(productCount);
           newOrder._items.Add(LineItem.Create(newOrder.OrderId,product.ProductId,new LineItemProductCount(productCount)));
        }
        return newOrder;
    }

    public void ChangeOrderStatus(OrderStatus newStatus)
    {
        if (OrderStatus is not OrderStatus.Placed)
            throw new InvalidOrderCancelStatus(OrderStatus);
        OrderStatus = newStatus;
    }

    public void CancelOrder()
    {
        if (OrderStatus is not OrderStatus.Placed)
            throw new InvalidOrderCancelStatus(OrderStatus);
        OrderStatus = OrderStatus.Cancelled;
    }
}