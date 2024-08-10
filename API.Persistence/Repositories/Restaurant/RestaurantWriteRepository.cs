using API.Application_.Repositories;
using API.Application_.Repositories.Restaurant;
using API.Persistence.Context;

namespace API.Persistence.Repositories.Restaurant
{
    public class RestaurantWriteRepository: WriteRepository<Domain.Entities.Restaurant>, IRestaurantWriteRepository
    {
        public RestaurantWriteRepository(APIDbContext context) : base(context)
        {
        }
    }
}
