using API.Domain.Entities.Common;

namespace API.Domain.Entities;

public class Menu : BaseEntity
{
    public string RestaurantId { get; set; }
    public string Name { get; set; }

    // Navigation Properties
    public Restaurant Restaurant { get; set; }
    public ICollection<Dish> Dishes { get; set; }
}