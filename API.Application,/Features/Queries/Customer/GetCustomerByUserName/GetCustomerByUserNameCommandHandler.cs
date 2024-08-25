using API.Application_.DTOs.Customer;
using API.Application_.Exceptions;
using API.Application_.Repositories.Customer;
using MediatR;

namespace API.Application_.Features.Queries.Customer.GetCustomerByUserName
{
    public class GetCustomerByUserNameCommandHandler : IRequestHandler<GetCustomerByUserNameQueriesRequest, GetCustomerDto>
    {
        readonly ICustomerReadRepository _customerReadRepository;

        public GetCustomerByUserNameCommandHandler(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        public async Task<GetCustomerDto> Handle(GetCustomerByUserNameQueriesRequest request, CancellationToken cancellationToken)
        {
            GetCustomerDto customerDto = await _customerReadRepository.GetCustomerByUserNameAsync(request.UserName);
            if (customerDto == null)
                throw new UserNotFoundException("Kullanıcı Bulunamadı");
            return customerDto;
        }
    }
}
