using MediatR;

namespace API.Application_.Features.Command.AppUser.LoginUser;

public class LoginUserCommandRequest :  IRequest<LoginUserCommandResponse>
{
    public string UserNameOrEmail { get; set; }
    public string Password { get; set; }

}