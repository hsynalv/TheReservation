using API.Application_.Features.Command.RestaurantOwner.UpdateProfilePicture;
using API.Application_.Features.Command.RestaurantOwner.UpdateRestaurantOwner;
using API.Application_.Features.Queries.RestuarantOwner.GetAllRestaurantOwner;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantOwnersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RestaurantOwnersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateRestaurantOwner(UpdateRestaurantOwnerCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _mediator.Send(new GetAllRestaurantOwnerQueriesRequest());
            return Ok(list);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetRestaurantOwner(string username)
        {
            var request = new GetRestaurantOwnerQueriesRequest()
            {
                UserName = username
            };

            var result = await  _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePhoto(UpdateRestaurantOwnerProfilePictureCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
