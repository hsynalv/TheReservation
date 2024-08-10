using API.Application_.Abstractions.Services;
using API.Application_.DTOs.User;
using API.Application_.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace API.Application_.Features.Command.AppUser.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    readonly IUserService _userService;

    public CreateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {

        CreateUserResponseDto response =  await _userService.CreateAsync(new()
        {
            Email = request.Email,
            Password = request.Password,
            UserName = request.UserName
        });
            

        // TODO: Hatalı giriş olsa bile 200 kodu dönüyor.
        return new()
        {
            Message = response.Message,
            Succeeded = response.Succeeded
        };
    }
}