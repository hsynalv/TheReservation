using API.Application_.DTOs.Customer;
using MediatR;

namespace API.Application_.Features.Queries.Customer.GetCustomerByUserId;

public class GetCustomerByUserIdQueriesRequest : IRequest<GetCustomerDto>
{
    public string Id { get; set; }
}