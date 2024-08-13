using API.Application_.DTOs;
using MediatR;

namespace API.Application_.Features.Command.Menu.UpdateMenu;

public class UpdateMenuCommandRequest : IRequest<ResultDto>
{
    public string MenuId { get; set; }
    public string Name { get; set; }
}