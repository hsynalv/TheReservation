using API.Application_.Features.Command.Review.CreateReview;
using API.Application_.Features.Queries.Review.GetReviewByRestaurant;
using API.Application_.Features.Queries.Review.GetReviewsByUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateReview(CreateReviewCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetReviewsByUserId(string userId)
        {
            GetReviewByUserQueriesRequest request = new() { Id = userId };
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetReviewByRestaurant(string restaurantId)
        {
            GetReviewByRestaurantQueriesRequest request = new() { RestaurantId = restaurantId};
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
