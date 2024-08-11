using API.Application_.Repositories.Customer;
using API.Persistence.Context;

namespace API.Persistence.Repositories.Customer;

public class CustomerWriteRepository : WriteRepository<Domain.Entities.Customer>, ICustomerWriteRepository
{
    public CustomerWriteRepository(APIDbContext context) : base(context)
    {
    }
}