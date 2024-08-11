using API.Domain.Entities.Common;

namespace API.Domain.Entities;

public class Review : BaseEntity
{
    public int Rating { get; set; }
    public string Comment { get; set; }
    public string UserId { get; set; }
    public string RestaurantId { get; set; }

    // Navigation Properties
    public Customer? User { get; set; }
    public Restaurant? Restaurant { get; set; }
}