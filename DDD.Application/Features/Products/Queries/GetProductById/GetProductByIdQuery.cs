using DDD.Application.Features.Products.DTOs;
using DDD.Application.Features.Products.Queries.GetProducts;
using MediatR;

namespace DDD.Application.Features.Products.Queries.GetProductById;

public record GetProductByIdQuery(Guid Id) : IRequest<ProductsQueryDto>;
