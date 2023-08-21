namespace VortiDex.Exceptions.BadRequestExceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message) { }

    public BadRequestException(string message, Exception InnerException) : base(message, InnerException) { }
}
