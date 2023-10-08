namespace DDD.Domain.Exceptions;

public class NoSufficientProductCountException:DomainException
{
    public NoSufficientProductCountException(Guid id,int count):base($"Product With ${id} Has No Sufficient Quantity {count} Piece")
    {
        
    }
}