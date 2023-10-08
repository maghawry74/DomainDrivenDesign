using DDD.Application.Features.Users.DOTs;
using MediatR;

namespace DDD.Application.Features.Users.Commands.Login;

public record LoginCommand(string Email, string Password) : IRequest<LoginResponseDto>;
