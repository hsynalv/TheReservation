using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs.Customer;
using API.Application_.DTOs.Review;
using API.Application_.Repositories.Customer;
using MediatR;

namespace API.Application_.Features.Queries.Customer.GetAllCustomer
{
    public class GetAllCustomerQueriesHandler : IRequestHandler<GetAllCustomerQueriesRequest, List<GetCustomerDto>>
    {
        private readonly ICustomerReadRepository _repository;

        public GetAllCustomerQueriesHandler(ICustomerReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCustomerDto>> Handle(GetAllCustomerQueriesRequest request, CancellationToken cancellationToken)
        {
                var list = await _repository.GetAllCustomersAsync();
                return list;
        }
    }
}
