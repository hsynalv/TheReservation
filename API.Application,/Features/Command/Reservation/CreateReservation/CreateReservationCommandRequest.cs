using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs;
using API.Application_.Repositories.RestaurantOwner;
using MediatR;

namespace API.Application_.Features.Command.Reservation.CreateReservation
{
    public class CreateReservationCommandRequest : IRequest<ResultDto>
    {
        public DateTime ReservationTime { get; set; }
        public int GuestCount { get; set; }
        public string UserId { get; set; }
        public string RestaurantId { get; set; }
        public string SpecialRequest { get; set; }
    }
}
