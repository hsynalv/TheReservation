using API.Domain.Entities.Common;
using API.Domain.Entities.Identity;

namespace API.Domain.Entities;

public class RestaurantOwner : BaseEntity
{
    // Navigation Properties
    public ICollection<Restaurant>? Restaurants { get; set; }

    // Navigation Property
    public AppUser AppUser { get; set; }
}