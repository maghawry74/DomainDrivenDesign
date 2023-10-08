using DDD.Domain.Exceptions;

namespace DDD.Domain.Models.Product.ValueObjects;

public record Price
{
    public decimal Value { get; private set; }

    public Price(decimal value)
    {
        if (value <= 0)
            throw new InvalidPriceException(value);
        Value = value;
    }
};