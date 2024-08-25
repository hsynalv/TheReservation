using API.Application_.DTOs.Customer;
using MediatR;

namespace API.Application_.Features.Queries.Customer.GetCustomerByUserName;

public class GetCustomerByUserNameQueriesRequest : IRequest<GetCustomerDto>
{
    public string UserName { get; set; }
}