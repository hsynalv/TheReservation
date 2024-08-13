using API.Application_.DTOs;
using MediatR;

namespace API.Application_.Features.Command.Review.CreateReview;

public class CreateReviewCommandRequest : IRequest<ResultDto>
{
    public int Rating { get; set; }
    public string Comment { get; set; }
    public string UserId { get; set; }
    public string RestaurantId { get; set; }
}