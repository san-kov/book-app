namespace BookApp.Exceptions;

public class AuthException : HttpException
{
    public AuthException(string message) 
        : base(StatusCodes.Status401Unauthorized, message) {}
}