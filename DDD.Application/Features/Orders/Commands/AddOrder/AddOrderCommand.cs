using DDD.Application.Features.Orders.DTOs;
using MediatR;

namespace DDD.Application.Features.Orders.Commands.AddOrder;

public class AddOrderCommand:IRequest<Guid>
{
    public NewOrderProductDto[] Products { get; set; }
    public Guid UserId { get; set; }
}