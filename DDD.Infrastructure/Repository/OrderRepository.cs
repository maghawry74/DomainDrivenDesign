using DDD.Domain.Models.Order.Aggregate;
using DDD.Domain.Models.Order.ValueObjects;
using DDD.Domain.Repository;
using DDD.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.Repository;

public class OrderRepository:GenericRepository<Order,Guid>,IOrderRepository
{
    public OrderRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<Order?> GetOrderDetails(Guid id)
    {
        return await Context.Set<Order>()
            .Include(o => o.LineItems).ThenInclude(l => l.Product)
            .Include(o => o.User)
            .FirstOrDefaultAsync(o => o.OrderId == new OrderId(id));
    }
}