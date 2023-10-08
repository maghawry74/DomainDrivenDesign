namespace DDD.Domain.Exceptions;

public class UserAssignedToOrderNotFoundException:DomainException
{
    public UserAssignedToOrderNotFoundException(Guid id):base($"User With Id ${id} Not Found.")
    {
        
    }
}