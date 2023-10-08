namespace DDD.Domain.Models.Product.ValueObjects;

public record ProductId
{
    public Guid Value { get; private set; }

    public ProductId()
    {
        Value=Guid.NewGuid();
    }

    public ProductId(Guid id)
    {
        Value = id;
    }
};