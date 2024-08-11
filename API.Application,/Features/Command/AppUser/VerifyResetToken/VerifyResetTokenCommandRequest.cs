using MediatR;

namespace API.Application_.Features.Command.AppUser.VerifyResetToken;

public class VerifyResetTokenCommandRequest : IRequest<VerifyResetTokenCommandResponse>
{
    public string ResetToken { get; set; }
    public string UserId { get; set; }
}