namespace DDD.Domain.Exceptions;

public class InvalidPriceException:DomainException
{
    public InvalidPriceException(decimal value):base($"{value} is not a valid price.Must Be Positive")
    {
        
    }
}