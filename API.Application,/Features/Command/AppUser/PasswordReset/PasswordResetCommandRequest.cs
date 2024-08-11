using MediatR;

namespace API.Application_.Features.Command.AppUser.PasswordReset;

public class PasswordResetCommandRequest : IRequest<PasswordResetCommandResponse>
{
    public string Email { get; set; }
}