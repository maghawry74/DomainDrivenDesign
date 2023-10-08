using DDD.Domain.Exceptions;

namespace DDD.Domain.Models.Product.ValueObjects;

public record ProductName
{
    public string Value { get;private set; }

    public ProductName(string name)
    {
        if(name.Length is < 3 or > 20)
            throw new InvalidProductNameException(name);
        Value = name;
    }
};