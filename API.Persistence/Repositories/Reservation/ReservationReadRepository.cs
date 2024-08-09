using API.Application_.Repositories;
using API.Application_.Repositories.Reservation;
using API.Persistence.Context;

namespace API.Persistence.Repositories.Reservation
{
    public class ReservationReadRepository : ReadRepository<Domain.Entity.Reservation>, IReservationReadRepository
    {
        public ReservationReadRepository(APIDbContext context) : base(context)
        {
        }
    }
}
