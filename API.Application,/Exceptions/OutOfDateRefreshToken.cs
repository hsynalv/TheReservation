namespace API.Application_.Exceptions;

public class OutOfDateRefreshToken : Exception
{
    public OutOfDateRefreshToken() : base("Refresh Token Süresi Geçmiş")
    {
    }

    public OutOfDateRefreshToken(string? message) : base(message)
    {
    }

    public OutOfDateRefreshToken(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}