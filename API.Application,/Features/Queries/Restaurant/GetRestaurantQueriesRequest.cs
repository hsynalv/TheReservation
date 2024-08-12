using API.Application_.DTOs.Restaurant;
using MediatR;

namespace API.Application_.Features.Queries.Restaurant;

public class GetRestaurantQueriesRequest : IRequest<GetRestaurantDto>
{
    public string RestaurantOwnerId { get; set; }
}