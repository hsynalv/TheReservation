﻿using API.Application_.DTOs;
using MediatR;

namespace API.Application_.Features.Command.AppUser.UpdatePassword;

public class UpdatePasswordCommandRequest : IRequest<ResultDto>
{
    public string UserId { get; set; }
    public string ResetToken { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
}