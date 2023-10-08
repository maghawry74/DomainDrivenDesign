using DDD.Application.Contracts.Services;
using DDD.Infrastructure.Context;

namespace DDD.Infrastructure.Services;

public class UnitWork:IUnitWork
{
    private readonly ApplicationContext _context;

    public UnitWork(ApplicationContext context)
    {
        _context = context;
    }
    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

    public async Task BeginTransaction()
    {
        await _context.Database.BeginTransactionAsync();
    }

    public async Task Commit()
    {
       await _context.Database.CommitTransactionAsync();
    }

    public async Task RollBack()
    {
        await _context.Database.RollbackTransactionAsync();
    }
}