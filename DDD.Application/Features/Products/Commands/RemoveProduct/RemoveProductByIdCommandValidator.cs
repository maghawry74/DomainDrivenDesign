using FluentValidation;

namespace DDD.Application.Features.Products.Commands.RemoveProduct;

public class RemoveProductByIdCommandValidator:AbstractValidator<RemoveProductByIdCommand>
{
    public RemoveProductByIdCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Product Id Is Required");
    }
}