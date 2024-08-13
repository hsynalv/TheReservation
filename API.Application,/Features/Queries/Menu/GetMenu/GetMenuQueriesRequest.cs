using API.Application_.DTOs.Menu;
using MediatR;

namespace API.Application_.Features.Queries.Menu.GetMenu;

public class GetMenuQueriesRequest : IRequest<GetMenuDto>
{
    public string MenuId { get; set; }
}