using AutoMapper;
using DDD.Application.Exceptions;
using DDD.Application.Features.Products.DTOs;
using DDD.Domain.Models.Product.ValueObjects;
using DDD.Domain.Repository;
using MediatR;

namespace DDD.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler:IRequestHandler<GetProductByIdQuery,ProductsQueryDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IProductRepository productRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<ProductsQueryDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByCondition(p=>p.ProductId==new ProductId(request.Id))
                      ?? throw new NotFoundException($"Product With Id {request.Id} Not Found");
        return _mapper.Map<ProductsQueryDto>(product);
    }
}