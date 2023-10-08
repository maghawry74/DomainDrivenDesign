using FluentValidation;

namespace DDD.Application.Features.Users.Commands.Register;

public class UserRegisterCommandValidator:AbstractValidator<UserRegisterCommand>
{
    public UserRegisterCommandValidator()
    {
        RuleFor(u => u.Password).NotEmpty().MinimumLength(8)
            .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$");
        RuleFor(u => u.Name).NotEmpty().MinimumLength(3).MaximumLength(10);
    }
}