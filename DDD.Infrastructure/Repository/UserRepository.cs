using DDD.Application.Contracts.Persistence.Repository;
using DDD.Domain.Models.User.Aggregate;
using DDD.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.Repository;

public class UserRepository:GenericRepository<User,Guid>,IUserRepository
{
    public UserRepository(ApplicationContext context) : base(context)
    {
    }
}