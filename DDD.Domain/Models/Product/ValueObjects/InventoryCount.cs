using DDD.Domain.Exceptions;

namespace DDD.Domain.Models.Product.ValueObjects;

public record InventoryCount
{
    public int  Value { get; private set; }

    public InventoryCount(int count)
    {
        if (count <= 0)
            throw new InvalidInventoryCountException(count);
        Value = count;
    }
};