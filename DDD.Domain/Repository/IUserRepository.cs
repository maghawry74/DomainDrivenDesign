using DDD.Domain.Models.User.Aggregate;
using DDD.Domain.Repository;

namespace DDD.Application.Contracts.Persistence.Repository;

public interface IUserRepository:IRepository<User,Guid>
{
    
}