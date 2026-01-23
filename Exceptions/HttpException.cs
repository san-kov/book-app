namespace BookApp.Exceptions;

public abstract class HttpException : Exception
{
    public int StatusCode { get; }

    protected HttpException(int statusCode, string message)
    {
        StatusCode = statusCode;
    }
}