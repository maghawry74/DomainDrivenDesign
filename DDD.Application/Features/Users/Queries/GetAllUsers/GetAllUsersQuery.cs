using DDD.Application.Features.Users.DOTs;
using MediatR;

namespace DDD.Application.Features.Users.Queries.GetAllUsers;

public class GetAllUsersQuery:IRequest<IEnumerable<UserDto>>
{
    
}