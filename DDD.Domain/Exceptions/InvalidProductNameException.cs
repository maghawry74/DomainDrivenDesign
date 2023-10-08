namespace DDD.Domain.Exceptions;

public class InvalidProductNameException:DomainException
{
    public InvalidProductNameException(string name)
        :base($"Product Name Must be Between 3 and 20. {name} is {name.Length}")
    {
        
    }
}