using DDD.Domain.Models.Order.Enums;
using MediatR;

namespace DDD.Application.Features.Orders.Commands.ChangeOrderStatus;

public record ChangeOrderStatusCommand(Guid Id,OrderStatus NewStatus):IRequest;