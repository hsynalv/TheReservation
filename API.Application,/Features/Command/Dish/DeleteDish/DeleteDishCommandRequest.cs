using API.Application_.DTOs;
using MediatR;

namespace API.Application_.Features.Command.Dish.DeleteDish;

public class DeleteDishCommandRequest : IRequest<ResultDto>
{
    public string DishId { get; set; }
}