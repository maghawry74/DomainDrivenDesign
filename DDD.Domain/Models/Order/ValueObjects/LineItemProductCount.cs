using DDD.Domain.Exceptions;

namespace DDD.Domain.Models.Order.ValueObjects;

public record LineItemProductCount
{
    public int Value { get; private set; }
    public LineItemProductCount(int value)
    {
        if (value <= 0)
            throw new InvalidLineItemProductCountException(value);
        Value = value;
    }
}