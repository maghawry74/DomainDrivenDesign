using System.Linq.Expressions;
using DDD.Domain.Repository;
using DDD.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.Repository;

public class GenericRepository<T,TId> :IRepository<T,TId> where T : class
{
    protected readonly ApplicationContext Context;

    public GenericRepository(ApplicationContext context)
    {
        Context = context;
    }
    public async Task<T?> GetByCondition(Expression<Func<T,bool>> expression)
    {
        return await Context.Set<T>().FirstOrDefaultAsync(expression);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await Context.Set<T>().ToListAsync();
    }

    public void Delete(T entity)
    {
        Context.Set<T>().Remove(entity);
    }

    public async Task Add(T entity)
    {
      await  Context.AddAsync(entity);
    }

    public void Update(T entity)
    {
        Context.Update(entity);
    }
}