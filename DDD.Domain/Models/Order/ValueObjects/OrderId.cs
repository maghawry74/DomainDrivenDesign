namespace DDD.Domain.Models.Order.ValueObjects;

public record OrderId
{
    public Guid Value { get; private set; } 

    public OrderId()
    {
     Value=Guid.NewGuid();
    }
    public OrderId(Guid id)
    {
        Value = id;
    }
};