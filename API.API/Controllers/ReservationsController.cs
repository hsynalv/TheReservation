using API.Application_.Features.Command.Reservation.CreateReservation;
using API.Application_.Features.Command.Reservation.DeleteReservation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateReservationCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string reservationId)
        {
            DeleteReservationCommandRequest request = new() { ReservationId = reservationId };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
