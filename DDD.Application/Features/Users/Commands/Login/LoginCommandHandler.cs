using System.IdentityModel.Tokens.Jwt;
using System.Text;
using DDD.Application.Contracts.Persistence.Repository;
using DDD.Application.Exceptions;
using DDD.Application.Features.Users.DOTs;
using DDD.Domain.Models.User.ValueObjects;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DDD.Application.Features.Users.Commands.Login;

public class LoginCommandHandler:IRequestHandler<LoginCommand,LoginResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IValidator<LoginCommand> _validator;
    private readonly IConfiguration _configuration;

    public LoginCommandHandler(IUserRepository userRepository,IValidator<LoginCommand> validator,IConfiguration configuration)
    {
        _userRepository = userRepository;
        _validator = validator;
        _configuration = configuration;
    }
    public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException(validationResult.ToString()!);

        var user = await _userRepository.GetByCondition(u =>
            (u.Email == new Email(request.Email)) && (u.Password == new Password(request.Password)))
            ?? throw  new UnAuthenticatedException();
        return new LoginResponseDto(GetToken());
    }

    private string GetToken()
    {
        var securityKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(
                _configuration["Authentication:Key"]!));

        var singingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            signingCredentials: singingCredentials,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddDays(1));
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}