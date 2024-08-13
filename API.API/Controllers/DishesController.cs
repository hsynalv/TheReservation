using API.Application_.Features.Command.Dish.CreateDish;
using API.Application_.Features.Command.Dish.DeleteDish;
using API.Application_.Features.Command.Dish.UpdateDish;
using API.Application_.Features.Queries.Dish.GetDish;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DishesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateDish(CreateDishCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateDish(UpdateDishCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteDish(DeleteDishCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetDish(string id)
        {
            var request = new GetDishQueriesRequest() { DishId = id };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
