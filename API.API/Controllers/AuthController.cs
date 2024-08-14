using API.Application_.DTOs;
using API.Application_.Features.Command.AppUser.ChangePhoneNumber;
using API.Application_.Features.Command.AppUser.CreateUser;
using API.Application_.Features.Command.AppUser.GoogleLogin;
using API.Application_.Features.Command.AppUser.LoginUser;
using API.Application_.Features.Command.AppUser.PasswordReset;
using API.Application_.Features.Command.AppUser.RefreshTokenLogin;
using API.Application_.Features.Command.AppUser.VerifyResetToken;
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
        ResultDto response = await _mediator.Send(createUserCommandRequest);
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

    [HttpPost("[action]")]
    public async Task<IActionResult> RefreshTokenLogin([FromBody] RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest)
    {
        RefreshTokenLoginCommandResponse response = await _mediator.Send(refreshTokenLoginCommandRequest);
        return Ok(response);
    }

    [HttpPost("password-reset")]
    public async Task<IActionResult> PasswordReset([FromBody] PasswordResetCommandRequest passwordResetCommandRequest)
    {
        PasswordResetCommandResponse response = await _mediator.Send(passwordResetCommandRequest);
        return Ok(response);
    }

    [HttpPost("verify-reset-token")]
    public async Task<IActionResult> VerifyResetToken([FromBody] VerifyResetTokenCommandRequest verifyResetTokenCommandRequest)
    {
        VerifyResetTokenCommandResponse response = await _mediator.Send(verifyResetTokenCommandRequest);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> ChangePhoneNumber(ChangePhoneNumberCommandRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}