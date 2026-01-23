namespace BookApp.Exceptions;

public class ForbiddenException : HttpException
{
    public ForbiddenException(string message) 
        : base(StatusCodes.Status403Forbidden, message) {}
}