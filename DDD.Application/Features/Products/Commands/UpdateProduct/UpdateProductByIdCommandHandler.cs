using DDD.Application.Contracts.Services;
using DDD.Application.Exceptions;
using DDD.Domain.Models.Product.ValueObjects;
using DDD.Domain.Repository;
using FluentValidation;
using MediatR;

namespace DDD.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductByIdCommandHandler:IRequestHandler<UpdateProductByIdCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitWork _unitWork;
    private readonly IValidator<UpdateProductByIdCommand> _validator;

    public UpdateProductByIdCommandHandler(IProductRepository productRepository,
        IUnitWork unitWork,
        IValidator<UpdateProductByIdCommand> validator)
    {
        _productRepository = productRepository;
        _unitWork = unitWork;
        _validator = validator;
    }
    public async Task Handle(UpdateProductByIdCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException(validationResult.ToString()!);
        var product = await _productRepository.GetByCondition(p=>p.ProductId==new ProductId(request.Id))
                      ?? throw new NotFoundException($"Product With Id {request.Id} Not Found");
        
        product.Update(request.Name,request.Price,request.InventoryCount,request.Image);
        _productRepository.Update(product);
        await _unitWork.SaveChanges();
    }
}