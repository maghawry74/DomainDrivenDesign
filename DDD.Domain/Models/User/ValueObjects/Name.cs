using DDD.Domain.Exceptions;

namespace DDD.Domain.Models.User.ValueObjects;

public record Name
{
    public string Value { get; init; }

    public Name(string value)
    {
        if (value.Length is > 10 or < 3)
            throw new InvalidStringLengthException(value);
        Value = value;
    }
}