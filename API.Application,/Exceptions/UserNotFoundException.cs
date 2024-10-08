﻿namespace API.Application_.Exceptions;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException() : base("Kullanıcı adı veya şifre hatalı.")
    {
    }

    public UserNotFoundException(string? message) : base(message)
    {
    }

    public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}