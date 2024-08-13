using API.Application_.DTOs.Restaurant;
using MediatR;

namespace API.Application_.Features.Queries.Restaurant.GetRestaurantByOwnerId;

public class GetRestaurantByOwnerIdQueriesRequest : IRequest<GetRestaurantDto>
{
    public string RestaurantOwnerId { get; set; }
}