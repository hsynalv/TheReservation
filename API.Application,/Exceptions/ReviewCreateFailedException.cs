namespace API.Application_.Exceptions;

public class ReviewCreateFailedException : Exception
{
    public ReviewCreateFailedException() : base("Yorum oluşturulurken beklenmeyen bir hatayla karşılaşıldı!")
    {
    }

    public ReviewCreateFailedException(string? message) : base(message)
    {
    }

    public ReviewCreateFailedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}