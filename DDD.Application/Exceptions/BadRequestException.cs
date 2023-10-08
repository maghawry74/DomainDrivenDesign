using System.Net;

namespace DDD.Application.Exceptions;

public class BadRequestException:ApplicationException
{

    public BadRequestException(string message):base((int)HttpStatusCode.BadRequest,message)
    {
        
    }
}