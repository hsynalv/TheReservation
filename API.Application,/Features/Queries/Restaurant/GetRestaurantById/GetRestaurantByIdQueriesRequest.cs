using API.Application_.DTOs.Restaurant;
using MediatR;

namespace API.Application_.Features.Queries.Restaurant.GetRestaurantById;

public class GetRestaurantByIdQueriesRequest : IRequest<GetRestaurantDto>
{
    public string Id { get; set; }
}