using AutoMapper;
using DDD.Application.Contracts.Persistence.Repository;
using DDD.Application.Features.Users.DOTs;
using MediatR;

namespace DDD.Application.Features.Users.Queries.GetAllUsers;

public class GetAllUsersQueryHandler:IRequestHandler<GetAllUsersQuery,IEnumerable<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(IUserRepository userRepository,IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAll();
        // return users.Select(u => _mapper.Map<UserDto>(u));
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }
    
}