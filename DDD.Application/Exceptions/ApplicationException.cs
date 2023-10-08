namespace DDD.Application.Exceptions;

public abstract class ApplicationException:Exception
{
    public int StatusCode { get;protected set; }

    protected ApplicationException()
    {
        
    }

    protected ApplicationException(int statusCode,string message):base(message)
    {
        StatusCode = statusCode;
    }
}