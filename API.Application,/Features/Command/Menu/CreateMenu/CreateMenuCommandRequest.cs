using API.Application_.DTOs;
using MediatR;

namespace API.Application_.Features.Command.Menu.CreateMenu;

public class CreateMenuCommandRequest : IRequest<ResultDto>
{
    public string RestaurantId { get; set; }
    public string Name { get; set; }
}