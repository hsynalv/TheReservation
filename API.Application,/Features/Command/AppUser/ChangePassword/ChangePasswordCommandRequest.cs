using MediatR;

namespace API.Application_.Features.Command.AppUser.ChangePassword;

public class ChangePasswordCommandRequest: IRequest<ChangePasswordCommandResponse>
{
    public string Username { get; set; }
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}