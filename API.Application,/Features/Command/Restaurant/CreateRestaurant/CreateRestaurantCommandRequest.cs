using API.Application_.DTOs;
using MediatR;

namespace API.Application_.Features.Command.Restaurant.CreateRestaurant;

public class CreateRestaurantCommandRequest : IRequest<ResultDto>
{
    public string RestaurantName { get; set; }
    public string Address { get; set; }
    public string RestaurantPhoneNumber { get; set; }
    public string CuisineType { get; set; }
    public string OwnerId { get; set; } // RestaurantOwner Id'si
}