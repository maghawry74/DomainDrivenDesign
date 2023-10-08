using System.Linq.Expressions;

namespace DDD.Domain.Repository;

public interface IRepository<T, in TId> where T : class
{
    Task<T?> GetByCondition(Expression<Func<T,bool>> expression);
    Task<IEnumerable<T>> GetAll();
    void Delete(T entity);
    Task Add(T entity);
    void Update(T entity);
}