using System.Text.RegularExpressions;
using DDD.Domain.Exceptions;

namespace DDD.Domain.Models.User.ValueObjects;

public record Email
{
    public string Value { get; init; }

    public Email(string value)
    {
        if (!Regex.Match(value, "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$").Success)
            throw new InvalidEmailException(value);
        Value = value;
    }
}