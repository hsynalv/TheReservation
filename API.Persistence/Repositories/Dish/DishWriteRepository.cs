using API.Application_.Repositories.Dish;
using API.Persistence.Context;

namespace API.Persistence.Repositories.Dish;

public class DishWriteRepository : WriteRepository<Domain.Entities.Dish>, IDishWriteRepository
{
    public DishWriteRepository(APIDbContext context) : base(context)
    {
    }
}