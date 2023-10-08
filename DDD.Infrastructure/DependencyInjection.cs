using DDD.Application.Contracts.Persistence.Repository;
using DDD.Application.Contracts.Services;
using DDD.Domain.Repository;
using DDD.Infrastructure.Context;
using DDD.Infrastructure.Repository;
using DDD.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException("Connection String is not Provided");
        services.AddDbContext<ApplicationContext>(opt =>
            opt.UseNpgsql(connectionString));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IUnitWork, UnitWork>();
        return services;
    }
}