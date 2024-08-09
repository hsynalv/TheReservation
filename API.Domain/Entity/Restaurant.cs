using API.Domain.Entity.Common;

namespace API.Domain.Entity;

public class Restaurant : BaseEntity
{
    public string RestaurantName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string CuisineType { get; set; }
    public string OwnerId { get; set; }

    // Navigation Properties
    public RestaurantOwner? Owner { get; set; }
    public ICollection<Reservation>? Reservations { get; set; }
    public ICollection<Review>? Reviews { get; set; }
}