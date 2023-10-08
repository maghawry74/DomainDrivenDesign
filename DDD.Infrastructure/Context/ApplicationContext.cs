using DDD.Domain.Models.User.Aggregate;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.Context;

public class ApplicationContext:DbContext
{
    public DbSet<User> Users { set; get; } = null!;

    public ApplicationContext()
    {
        
    }
    public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}