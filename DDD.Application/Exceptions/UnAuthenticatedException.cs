using System.Net;
using DDD.Domain.Exceptions;

namespace DDD.Application.Exceptions;

public class UnAuthenticatedException:ApplicationException
{
    public UnAuthenticatedException():base((int)HttpStatusCode.Unauthorized,"Wrong Email Or Password")
    {
        
    }
}