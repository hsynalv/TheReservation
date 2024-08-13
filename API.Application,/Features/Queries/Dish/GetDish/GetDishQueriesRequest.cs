using API.Application_.DTOs.Dish;
using MediatR;

namespace API.Application_.Features.Queries.Dish.GetDish;

public class GetDishQueriesRequest : IRequest<GetDishDto>
{
    public string DishId { get; set; }
}