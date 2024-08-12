using API.Application_.DTOs.RestaurantOwner;
using MediatR;

public class GetRestaurantOwnerQueriesRequest : IRequest<GetRestaurantOwnerDto>
{
    public string UserName { get; set; }
}