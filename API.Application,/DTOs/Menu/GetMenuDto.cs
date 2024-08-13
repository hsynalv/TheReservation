using API.Application_.DTOs.Dish;
using API.Domain.Entities;

namespace API.Application_.DTOs.Menu;

public class GetMenuDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<GetDishDto> Dishes { get; set; }
}