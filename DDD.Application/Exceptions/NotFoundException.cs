using System.Net;

namespace DDD.Application.Exceptions;

public class NotFoundException:ApplicationException
{
    public NotFoundException(string message):base((int)HttpStatusCode.NotFound,message)
    {
        
    }
}