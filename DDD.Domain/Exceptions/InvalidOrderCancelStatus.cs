using DDD.Domain.Models.Order.Enums;

namespace DDD.Domain.Exceptions;

public class InvalidOrderCancelStatus:DomainException
{
    public InvalidOrderCancelStatus(OrderStatus orderStatus):base($"You Can't Cancel an Order While it's in {orderStatus.ToString()} Status")
    {
        
    }
}