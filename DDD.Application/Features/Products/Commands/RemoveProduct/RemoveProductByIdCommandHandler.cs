using DDD.Application.Contracts.Services;
using DDD.Application.Exceptions;
using DDD.Domain.Models.Product.ValueObjects;
using DDD.Domain.Repository;
using FluentValidation;
using MediatR;

namespace DDD.Application.Features.Products.Commands.RemoveProduct;

public class RemoveProductByIdCommandHandler:IRequestHandler<RemoveProductByIdCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IValidator<RemoveProductByIdCommand> _validator;
    private readonly IUnitWork _unitWork;

    public RemoveProductByIdCommandHandler(IProductRepository productRepository,
        IValidator<RemoveProductByIdCommand> validator,
        IUnitWork unitWork)
    {
        _productRepository = productRepository;
        _validator = validator;
        _unitWork = unitWork;
    }
    public async Task Handle(RemoveProductByIdCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException(validationResult.ToString()!);

        var product = await _productRepository.GetByCondition(p=>p.ProductId==new ProductId(request.Id))
                      ?? throw new NotFoundException($"Product With Id {request.Id} Not Found");
        _productRepository.Delete(product);
        await _unitWork.SaveChanges();
    }
}