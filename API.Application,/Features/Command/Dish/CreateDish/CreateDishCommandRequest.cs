using API.Application_.DTOs;
using MediatR;

namespace API.Application_.Features.Command.Dish.CreateDish;

public class CreateDishCommandRequest : IRequest<ResultDto>
{
    public string MenuId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string PhotoUrl { get; set; } // Photo URL or Path
}