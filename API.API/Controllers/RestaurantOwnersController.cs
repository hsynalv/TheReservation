using API.Application_.Features.Command.RestaurantOwner.UpdateRestaurantOwner;
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
    }
}
