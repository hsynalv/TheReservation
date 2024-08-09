﻿using API.Persistence.Context;

namespace API.Persistence.Repositories.Reservation;

public class ReservationWriteRepository : WriteRepository<Domain.Entity.Reservation>, Application_.Repositories.Reservation.IReservationWriteRepository
{
    public ReservationWriteRepository(APIDbContext context) : base(context)
    {
    }
}