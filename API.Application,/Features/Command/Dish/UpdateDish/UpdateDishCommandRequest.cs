using API.Application_.DTOs;
using MediatR;

namespace API.Application_.Features.Command.Dish.UpdateDish;

public class UpdateDishCommandRequest : IRequest<ResultDto>
{
    public string dishId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string PhotoUrl { get; set; } // Photo URL or Path
}