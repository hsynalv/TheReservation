using API.Application_.Repositories.Address;
using API.Persistence.Context;

namespace API.Persistence.Repositories.Address;

public class AddressWriteRepository : WriteRepository<Domain.Entities.Address>, IAddressWriteRepository
{
    public AddressWriteRepository(APIDbContext context) : base(context)
    {
    }
}