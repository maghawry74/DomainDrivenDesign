using DDD.Application.Features.Products.DTOs;
using MediatR;

namespace DDD.Application.Features.Products.Queries.GetProducts;

public record GetProductsQuery() : IRequest<IEnumerable<ProductsQueryDto>>;
