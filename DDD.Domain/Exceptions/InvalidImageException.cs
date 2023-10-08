namespace DDD.Domain.Exceptions;

public class InvalidImageException:DomainException
{
    public InvalidImageException(string message):base(message)
    {
        
    }
}