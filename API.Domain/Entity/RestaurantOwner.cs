using API.Domain.Entity.Identity;

namespace API.Domain.Entity;

public class RestaurantOwner : AppUser
{
    // Navigation Properties
    public ICollection<Restaurant>? Restaurants { get; set; }
}