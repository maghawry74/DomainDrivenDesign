using DDD.Application.Contracts.Persistence.Repository;
using DDD.Domain.Models.Product.Aggregate;

namespace DDD.Domain.Repository;

public interface IProductRepository:IRepository<Product,Guid>
{
    Task<List<Product>> FetchProductsForOrder(Guid[] productIds);
}