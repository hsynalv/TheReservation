using API.Domain.Entities.Common;
using API.Domain.Entities.Identity;

namespace API.Domain.Entities;

public class RestaurantOwner : BaseEntity
{
    public string? Name { get; set; }

    public string? LastName { get; set; }

    // Navigation Properties
    public ICollection<Restaurant>? Restaurants { get; set; }

    // Navigation Property
    public AppUser AppUser { get; set; }
}