namespace DDD.Domain.Exceptions;

public class InvalidStringLengthException:DomainException
{
    public int Count { get; init; }

    public InvalidStringLengthException(string value):base($"{value.Length} is Not a Valid Length")
    {
        Count = value.Length;
    }
}