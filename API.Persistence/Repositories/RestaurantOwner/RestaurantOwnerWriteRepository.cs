using API.Application_.Repositories.RestaurantOwner;
using API.Persistence.Context;

namespace API.Persistence.Repositories.RestaurantOwner
{
    public class RestaurantOwnerWriteRepository : WriteRepository<Domain.Entities.RestaurantOwner>, IRestaurantOwnerWriteRepository
    {
        public RestaurantOwnerWriteRepository(APIDbContext context) : base(context)
        {
        }
    }
}
