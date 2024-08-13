using API.Application_.DTOs.Review;
using MediatR;

namespace API.Application_.Features.Queries.Review.GetReviewByRestaurant;

public class GetReviewByRestaurantQueriesRequest : IRequest<List<GetRestaurantReviewDto>>
{
    public string RestaurantId { get; set; }
}