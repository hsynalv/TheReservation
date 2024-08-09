using API.Domain.Entity.Common;

namespace API.Domain.Entity;

public class Reservation : BaseEntity
{
    public DateTime ReservationTime { get; set; }
    public int GuestCount { get; set; }
    public string UserId { get; set; }
    public string RestaurantId { get; set; }

    // Navigation Properties
    public User? User { get; set; }
    public Restaurant? Restaurant { get; set; }
}