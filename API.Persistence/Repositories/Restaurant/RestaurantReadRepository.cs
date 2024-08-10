using API.Application_.Repositories;
using API.Application_.Repositories.Restaurant;
using API.Persistence.Context;

namespace API.Persistence.Repositories.Restaurant;

public class RestaurantReadRepository : ReadRepository<Domain.Entities.Restaurant>, IRestaurantReadRepository
{
    public RestaurantReadRepository(APIDbContext context) : base(context)
    {
    }
}