using DDD.Application.Contracts.Persistence.Repository;
using DDD.Domain.Models.Order.Aggregate;

namespace DDD.Domain.Repository;

public interface IOrderRepository:IRepository<Order,Guid>
{
    Task<Order?> GetOrderDetails(Guid id);
}