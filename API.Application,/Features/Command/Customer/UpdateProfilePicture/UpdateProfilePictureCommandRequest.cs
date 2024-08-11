using MediatR;

namespace API.Application_.Features.Command.Customer.UpdateProfilePicture;

public class UpdateProfilePictureCommandRequest : IRequest<UpdateProfilePictureCommandResponse>
{
    public string username { get; set; }
    public string url { get; set; }
}