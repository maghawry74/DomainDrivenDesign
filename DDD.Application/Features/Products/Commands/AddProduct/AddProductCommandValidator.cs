using FluentValidation;

namespace DDD.Application.Features.Products.Commands.AddProduct;

public class AddProductCommandValidator:AbstractValidator<AddProductCommand>
{
    public AddProductCommandValidator()
    {
        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price Must Be Bigger Than Zero");
        
        RuleFor(x => x.Image)
            .NotEmpty()
            .WithMessage("Image Path is Required");
        
        RuleFor(x => x.InventoryCount)
            .GreaterThan(0)
            .WithMessage("InventoryCount Must Be Bigger Than Zero");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name Is Required")
            .MinimumLength(3)
            .MaximumLength(20)
            .WithMessage("Name Length Must Be Between 3 and 20");

    }
}