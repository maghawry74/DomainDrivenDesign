namespace DDD.Domain.Exceptions;

public class PlacedProductsInOrderNotFound:DomainException
{
    public PlacedProductsInOrderNotFound():base("Some or All Products Not Found")
    {
        
    }
}