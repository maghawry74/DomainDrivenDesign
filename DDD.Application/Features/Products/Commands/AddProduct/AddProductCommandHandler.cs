using AutoMapper;
using DDD.Application.Contracts.Services;
using DDD.Application.Exceptions;
using DDD.Domain.Models.Product.Aggregate;
using DDD.Domain.Repository;
using FluentValidation;
using MediatR;

namespace DDD.Application.Features.Products.Commands.AddProduct;

public class AddProductCommandHandler:IRequestHandler<AddProductCommand,Guid>
{
    private readonly IProductRepository _productRepository;
    private readonly IValidator<AddProductCommand> _validator;
    private readonly IUnitWork _unitWork;

    public AddProductCommandHandler(IProductRepository productRepository,
        IValidator<AddProductCommand> validator,
        IUnitWork unitWork)
    {
        _productRepository = productRepository;
        _validator = validator;
        _unitWork = unitWork;
    }
    public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request,cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException(validationResult.ToString()!);

        var newProduct = Product.Create(request.Name, request.Price, request.InventoryCount, request.Image);
        await _productRepository.Add(newProduct);
        await _unitWork.SaveChanges();
        return newProduct.ProductId.Value;
    }
}