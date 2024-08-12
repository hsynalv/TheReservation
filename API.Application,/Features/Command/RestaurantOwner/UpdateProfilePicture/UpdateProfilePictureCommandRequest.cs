using API.Application_.DTOs;
using MediatR;

namespace API.Application_.Features.Command.RestaurantOwner.UpdateProfilePicture;

public class UpdateRestaurantOwnerProfilePictureCommandRequest : IRequest<ResultDto>
{
    public string username { get; set; }
    public string url { get; set; }
}