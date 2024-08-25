using API.Application_.DTOs;
using MediatR;

namespace API.Application_.Features.Command.RestaurantOwner.CreateRestaurantOwner;

public class CreateRestaurantOwnerCommandRequest : IRequest<ResultDto>
{
    public string Id  { get; set; }
    public string? Name { get; set; }

    public string? LastName { get; set; }
}