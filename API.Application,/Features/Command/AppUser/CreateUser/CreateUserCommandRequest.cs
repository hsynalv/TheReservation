using MediatR;

namespace API.Application_.Features.Command.AppUser.CreateUser;

public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool UserType { get; set; }
}