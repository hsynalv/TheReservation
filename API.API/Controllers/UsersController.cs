using API.Application_.DTOs;
using API.Application_.Features.Command.AppUser.ChangePassword;
using API.Application_.Features.Command.AppUser.CreateUser;
using API.Application_.Features.Command.AppUser.GoogleLogin;
using API.Application_.Features.Command.AppUser.LoginUser;
using API.Application_.Features.Command.AppUser.UpdatePassword;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommandRequest request)
        {
            ResultDto result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ResetPassword(
            [FromBody] UpdatePasswordCommandRequest updatePasswordCommandRequest)
        {
            ResultDto response = await _mediator.Send(updatePasswordCommandRequest);
            return Ok(response);
        }

        
    }
}
