using API.Application_.DTOs.Restaurant;
using MediatR;

namespace API.Application_.Features.Queries.Restaurant.GetAllRestaurant;

public class GetAllRestaurantQueriesRequest : IRequest<List<GetRestaurantDto>>
{

}