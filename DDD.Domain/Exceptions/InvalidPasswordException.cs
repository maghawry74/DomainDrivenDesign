namespace DDD.Domain.Exceptions;

public class InvalidPasswordException:DomainException
{
    public string Value { get; }

    public InvalidPasswordException(string value):base($"{value} is not a Valid Password")
    {
        Value = value;
    }
}