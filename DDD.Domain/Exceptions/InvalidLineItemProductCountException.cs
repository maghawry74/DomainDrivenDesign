namespace DDD.Domain.Exceptions;

public class InvalidLineItemProductCountException:DomainException
{
    public InvalidLineItemProductCountException(int number):base($"{number} is not a valid line Item Quantity")
    {
        
    }
}