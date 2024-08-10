using API.Application_.Features.Command.AppUser.CreateUser;
using API.Application_.Features.Command.AppUser.GoogleLogin;
using API.Application_.Features.Command.AppUser.LoginUser;
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

        
    }
}
