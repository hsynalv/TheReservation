using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs;
using MediatR;

namespace API.Application_.Features.Command.Reservation.DeleteReservation
{
    public class DeleteReservationCommandRequest : IRequest<ResultDto>
    {
        public string ReservationId { get; set; }
    }
}
