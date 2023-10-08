namespace DDD.Domain.Exceptions;

public class InvalidOrderPriceException:DomainException
{
    public InvalidOrderPriceException():base($"Order Price Must Be Positive.")
    {
        
    }
}