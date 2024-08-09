using API.Domain.Entity.Common;

namespace API.Domain.Entity;

public class Review : BaseEntity
{
    public int Rating { get; set; }
    public string Comment { get; set; }
    public string UserId { get; set; }
    public string RestaurantId { get; set; }

    // Navigation Properties
    public User? User { get; set; }
    public Restaurant? Restaurant { get; set; }
}