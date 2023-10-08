using DDD.Application.Features.Orders.Commands.CancelOrder;
using DDD.Domain.Models.Order.Enums;
using FluentValidation;

namespace DDD.Application.Features.Orders.Commands.ChangeOrderStatus;

public class ChangeOrderStatusCommandValidator : AbstractValidator<ChangeOrderStatusCommand>
{
    public ChangeOrderStatusCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        RuleFor(x => x.NewStatus)
            .IsInEnum()
            .NotEqual(OrderStatus.Cancelled);
    }
}