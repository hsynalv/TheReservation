using API.Application_.DTOs;
using MediatR;

namespace API.Application_.Features.Command.Menu.DeleteMenu;

public class DeleteMenuCommandRequest : IRequest<ResultDto>
{
    public string MenuId { get; set; }
}