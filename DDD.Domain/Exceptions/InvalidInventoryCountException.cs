namespace DDD.Domain.Exceptions;

public class InvalidInventoryCountException:DomainException
{
    public InvalidInventoryCountException(int value):base($"{value} is not a valid inventory count.Must be Positive")
    {
        
    }
}