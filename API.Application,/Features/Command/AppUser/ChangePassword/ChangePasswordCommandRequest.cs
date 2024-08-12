using API.Application_.DTOs;
using MediatR;

namespace API.Application_.Features.Command.AppUser.ChangePassword;

public class ChangePasswordCommandRequest: IRequest<ResultDto>
{
    public string Username { get; set; }
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}