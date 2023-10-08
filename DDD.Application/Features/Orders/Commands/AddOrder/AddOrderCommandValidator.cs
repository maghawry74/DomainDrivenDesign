using DDD.Application.Features.Orders.DTOs;
using FluentValidation;

namespace DDD.Application.Features.Orders.Commands.AddOrder;

public class AddOrderCommandValidator:AbstractValidator<AddOrderCommand>
{
    public AddOrderCommandValidator()
    {
        RuleFor(o => o.UserId)
            .NotEmpty()
            .WithMessage("User Id Is Required");

        RuleFor(o => o.Products.Length)
            .GreaterThan(0);
        
        RuleForEach(o => o.Products)
            .ChildRules(product =>
            {
                product.RuleFor(p => p.Id)
                    .NotEmpty();
                product.RuleFor(p => p.Quantity)
                    .GreaterThan(0);
            });
    }
}
