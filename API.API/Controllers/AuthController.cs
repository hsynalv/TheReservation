using API.Application_.Features.Command.AppUser.CreateUser;
using API.Application_.Features.Command.AppUser.GoogleLogin;
using API.Application_.Features.Command.AppUser.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{

    readonly IMediator _mediator;
    public AuthController(IMediator mediator)
    {
        _mediator = mediator;

    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
    {
        CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
    {
        LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
        return Ok(response);
    }

    [HttpPost("google-login")]
    public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest googleLoginCommandRequest)
    {
        GoogleLoginCommandResponse response = await _mediator.Send(googleLoginCommandRequest);
        return Ok(response);
    }
}