using MediatR;

namespace DDD.Application.Features.Orders.Commands.CancelOrder;

public record CancelOrderCommand(Guid Id):IRequest;