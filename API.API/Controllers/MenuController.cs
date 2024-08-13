using API.Application_.Features.Command.Menu.CreateMenu;
using API.Application_.Features.Command.Menu.DeleteMenu;
using API.Application_.Features.Command.Menu.UpdateMenu;
using API.Application_.Features.Queries.Menu.GetAllMenuByRestaurant;
using API.Application_.Features.Queries.Menu.GetMenu;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateMenu(CreateMenuCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateMenu(UpdateMenuCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteMenu(DeleteMenuCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetMenu(string id)
        {
            var result = await _mediator.Send(new GetMenuQueriesRequest() { MenuId = id });
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllMenuByRestaurantId(string id)
        {
            var result = await _mediator.Send(new GetAllMenuByRestaurantQueriesRequest() { RestaurantId = id });
            return Ok(result);
        }


    }
}
