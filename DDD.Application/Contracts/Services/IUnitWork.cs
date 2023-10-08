namespace DDD.Application.Contracts.Services;

public interface IUnitWork
{
    Task SaveChanges();
    Task BeginTransaction();
    Task Commit();
    Task RollBack();
}