using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs.Customer;

namespace API.Application_.Repositories.Customer
{
    public interface ICustomerReadRepository : IReadRepository<Domain.Entities.Customer>
    {
        Task<GetCustomerDto> GetCustomerAsync(string username);
        Task<List<GetCustomerDto>> GetAllCustomersAsync();
    }
}
