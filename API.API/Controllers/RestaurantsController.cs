using API.Application_.Features.Command.Restaurant.CreateRestaurant;
using API.Application_.Features.Command.Restaurant.UpdateRestaurant;
using API.Application_.Features.Queries.Restaurant;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RestaurantsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRestaurant(CreateRestaurantCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetRestaurant(string restaurantOwnerId)
        {
            GetRestaurantQueriesRequest request = new() { RestaurantOwnerId = restaurantOwnerId };
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateRestaurant(UpdateRestaurantCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

    }
}
