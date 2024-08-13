namespace API.Application_.DTOs.Review;

public class GetRestaurantReviewDto
{
    public string Id { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
    public string CustomerName { get; set; }
}