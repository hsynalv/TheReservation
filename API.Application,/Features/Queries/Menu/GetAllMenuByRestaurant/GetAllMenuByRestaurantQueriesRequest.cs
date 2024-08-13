using API.Application_.DTOs.Menu;
using MediatR;

namespace API.Application_.Features.Queries.Menu.GetAllMenuByRestaurant;

public class GetAllMenuByRestaurantQueriesRequest : IRequest<List<GetMenuDto>>
{
    public string RestaurantId { get; set; }
}