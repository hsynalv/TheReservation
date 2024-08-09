using API.Domain.Entity.Common;

namespace API.Domain.Entity;

public class Menu : BaseEntity
{
    public string RestaurantId { get; set; }
    public string Name { get; set; }

    // Navigation Properties
    public Restaurant Restaurant { get; set; }
    public ICollection<Dish> Dishes { get; set; }
}