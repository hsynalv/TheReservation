﻿using API.Domain.Entities.Common;

namespace API.Domain.Entities;

public class Reservation : BaseEntity
{
    public DateTime ReservationTime { get; set; }
    public int GuestCount { get; set; }
    public string UserId { get; set; }
    public string RestaurantId { get; set; }

    // Navigation Properties
    public Customer? User { get; set; }
    public Restaurant? Restaurant { get; set; }
}