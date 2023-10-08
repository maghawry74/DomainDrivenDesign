using DDD.Application.Features.Orders.DTOs;
using MediatR;

namespace DDD.Application.Features.Orders.Queries.GetOrders;

public record GetOrdersQuery() : IRequest<IEnumerable<AllOrderDto>>;
