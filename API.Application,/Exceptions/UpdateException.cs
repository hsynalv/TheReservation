namespace API.Application_.Exceptions;

public class UpdateException : Exception
{
    public UpdateException() : base("Güncelleme sırasında bir hata meydana geldi")
    {
    }

    public UpdateException(string? message) : base(message)
    {
    }

    public UpdateException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}