using API.Application_.DTOs;

namespace API.Application_.Features.Command.AppUser.RefreshTokenLogin;

public class RefreshTokenLoginCommandResponse
{
    public Token Token { get; set; }
}