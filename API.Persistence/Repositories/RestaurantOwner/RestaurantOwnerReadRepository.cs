using API.Application_.Repositories.RestaurantOwner;
using API.Persistence.Context;

namespace API.Persistence.Repositories.RestaurantOwner;

public class RestaurantOwnerReadRepository : ReadRepository<Domain.Entities.RestaurantOwner>, IRestaurantOwnerReadRepository
{
    public RestaurantOwnerReadRepository(APIDbContext context) : base(context)
    {
    }
}