using API.Application_.DTOs;
using MediatR;

namespace API.Application_.Features.Command.AppUser.CreateUser;

public class CreateUserCommandRequest : IRequest<ResultDto>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Name { get; set; }

    public string? LastName { get; set; }
    public bool UserType { get; set; }
}