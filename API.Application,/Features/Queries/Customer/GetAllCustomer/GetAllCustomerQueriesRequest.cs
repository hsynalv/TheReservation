using API.Application_.DTOs.Customer;
using MediatR;

namespace API.Application_.Features.Queries.Customer.GetAllCustomer;

public class GetAllCustomerQueriesRequest : IRequest<List<GetCustomerDto>>
{

}