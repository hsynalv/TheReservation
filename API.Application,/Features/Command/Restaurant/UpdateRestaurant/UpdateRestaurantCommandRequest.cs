using API.Application_.DTOs;
using API.Application_.DTOs.Address;
using MediatR;

namespace API.Application_.Features.Command.Restaurant.UpdateRestaurant;

public class UpdateRestaurantCommandRequest : IRequest<ResultDto>
{
    public string Id { get; set; }
    public string RestaurantName { get; set; }
    public string Address { get; set; }
    public string RestaurantPhoneNumber { get; set; }
    public string CuisineType { get; set; }

    public AddressDto AddressDto { get; set; }
}