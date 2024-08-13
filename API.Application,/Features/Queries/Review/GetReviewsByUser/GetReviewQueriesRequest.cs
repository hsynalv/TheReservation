using API.Application_.DTOs.Review;
using MediatR;

namespace API.Application_.Features.Queries.Review.GetReviewsByUser;

public class GetReviewByUserQueriesRequest : IRequest<List<GetUserReviewDto>>
{
    public string Id { get; set; }
}