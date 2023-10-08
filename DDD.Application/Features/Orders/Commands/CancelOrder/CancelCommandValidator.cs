using FluentValidation;

namespace DDD.Application.Features.Orders.Commands.CancelOrder;

public class CancelCommandValidator : AbstractValidator<CancelOrderCommand>
{
    public CancelCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}