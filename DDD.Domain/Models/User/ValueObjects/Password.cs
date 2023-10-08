using System.Text.RegularExpressions;
using DDD.Domain.Exceptions;

namespace DDD.Domain.Models.User.ValueObjects;

public record Password
{
    public string Value { get;private set; }

    public Password(string value)
    {
        if (!Regex.Match(value, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$").Success)
            throw new InvalidPasswordException(value);
        Value = value;
    }
}