using MediatR;

namespace API.Application_.Features.Command.RestaurantOwner.CreateRestaurantOwner;

public class CreateRestaurantOwnerCommandRequest : IRequest<CreateRestaurantOwnerCommandResponse>
{
    public string Id  { get; set; }
}