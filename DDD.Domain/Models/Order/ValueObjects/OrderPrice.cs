using DDD.Domain.Exceptions;

namespace DDD.Domain.Models.Order.ValueObjects;

public record OrderPrice
{
    public decimal Value { get; private set; }

    
    public OrderPrice(decimal value)
    {
        if (value is <= 0 )
            throw new InvalidOrderPriceException();
        Value = value;
    }
};