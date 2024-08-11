using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.Repositories.Customer;
using API.Application_.Repositories.RestaurantOwner;
using API.Persistence.Context;

namespace API.Persistence.Repositories.Customer
{
    public class CustomerReadRepository : ReadRepository<Domain.Entities.Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(APIDbContext context) : base(context)
        {
        }
    }
}
