using DDD.Application.Features.Orders.DTOs;
using MediatR;

namespace DDD.Application.Features.Orders.Queries.GetOrderById;

public record GetOrderByIdQuery(Guid Id) : IRequest<OrderDetailsDto>;
