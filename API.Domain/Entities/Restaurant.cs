using API.Domain.Entities.Common;

namespace API.Domain.Entities;

public class Restaurant : BaseEntity
{
    public string RestaurantName { get; set; }
    public string Address { get; set; }
    public string RestaurantPhoneNumber { get; set; }
    public string CuisineType { get; set; }
    public string OwnerId { get; set; }

    // Navigation Properties
    public RestaurantOwner? Owner { get; set; }
    public ICollection<Reservation>? Reservations { get; set; }
    public ICollection<Review>? Reviews { get; set; }
    public ICollection<Menu>? Menus { get; set; } // Menu Property added
}