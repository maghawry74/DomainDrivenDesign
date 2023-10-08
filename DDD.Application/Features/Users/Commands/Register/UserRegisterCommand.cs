using DDD.Application.Features.Users.Commands;
using MediatR;

namespace DDD.Application.Features.Users.Commands.Register;

public class UserRegisterCommand:IRequest<UserRegisterDto>
{
    public string Name { get; set; } = null!;
    public string Email { get; set; }= null!;
    public string Password { get; set; }= null!;
}