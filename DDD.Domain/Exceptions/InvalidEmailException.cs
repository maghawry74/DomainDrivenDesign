namespace DDD.Domain.Exceptions;

public class InvalidEmailException:DomainException
{
    public readonly string Value;

    public InvalidEmailException(string value):base($"{value} is Not a Valid Domain Email")
    {
        Value = value;
    }
}