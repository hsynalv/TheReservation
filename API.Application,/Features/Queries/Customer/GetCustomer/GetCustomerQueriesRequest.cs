using API.Application_.DTOs.Customer;
using MediatR;

namespace API.Application_.Features.Queries.Customer.GetCustomer;

public class GetCustomerQueriesRequest : IRequest<GetCustomerDto>
{
    public string UserName { get; set; }
}