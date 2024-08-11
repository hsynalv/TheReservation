using API.Application_.Repositories.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs.Customer;
using API.Application_.Exceptions;

namespace API.Application_.Features.Queries.Customer.GetCustomer
{
    public class GetCustomerCommandHandler : IRequestHandler<GetCustomerQueriesRequest, GetCustomerDto>
    {
        readonly ICustomerReadRepository _customerReadRepository;

        public GetCustomerCommandHandler(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        public async Task<GetCustomerDto> Handle(GetCustomerQueriesRequest request, CancellationToken cancellationToken)
        {
            GetCustomerDto customerDto = await _customerReadRepository.GetCustomerAsync(request.UserName);
            if (customerDto == null)
                throw new UserNotFoundException("Kullanıcı Bulunamadı");
            return customerDto;
        }
    }
}
