using API.Application_.Repositories.Address;
using API.Persistence.Context;

namespace API.Persistence.Repositories.Address
{
    public class AddressReadRepository : ReadRepository<Domain.Entities.Address>, IAddressReadRepository
    {
        public AddressReadRepository(APIDbContext context) : base(context)
        {
        }
    }
}
