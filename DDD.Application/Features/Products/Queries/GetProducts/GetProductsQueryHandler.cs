using AutoMapper;
using DDD.Application.Features.Products.DTOs;
using DDD.Domain.Repository;
using MediatR;

namespace DDD.Application.Features.Products.Queries.GetProducts;

public class GetProductsQueryHandler:IRequestHandler<GetProductsQuery,IEnumerable<ProductsQueryDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(
        IProductRepository productRepository,
        IMapper mapper
        )
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ProductsQueryDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAll();
        return _mapper.Map<IEnumerable<ProductsQueryDto>>(products);
    }
}