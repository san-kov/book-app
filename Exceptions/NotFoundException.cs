namespace BookApp.Exceptions;

public class NotFoundException : HttpException
{
    public NotFoundException(string message) 
        : base(StatusCodes.Status404NotFound, message) {}
}