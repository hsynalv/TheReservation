using API.Domain.Entities.Identity;

namespace API.Domain.Entities;

public class RestaurantOwner : AppUser
{
    // Navigation Properties
    public ICollection<Restaurant>? Restaurants { get; set; }
}