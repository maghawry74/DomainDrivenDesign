using DDD.Domain.Models.Order.Enums;
using DDD.Domain.Models.Product.Aggregate;
using DDD.Domain.Models.Product.ValueObjects;
using DDD.Domain.Repository;
using DDD.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.Repository;

public class ProductRepository:GenericRepository<Product,Guid>,IProductRepository
{
    public ProductRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<List<Product>> FetchProductsForOrder(Guid[] productIds)
    {
        var ids = productIds.Select(id => new ProductId(id));
        return await Context.Set<Product>()
            .Where(p => ids.Contains(p.ProductId))
            .ToListAsync();
    }
}