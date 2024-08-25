using API.Application_.DTOs.Customer;
using API.Application_.Exceptions;
using API.Application_.Repositories.Customer;
using MediatR;

namespace API.Application_.Features.Queries.Customer.GetCustomerByUserId
{
    public class GetCustomerByUserIdCommandHandler : IRequestHandler<GetCustomerByUserIdQueriesRequest, GetCustomerDto>
    {
        readonly ICustomerReadRepository _customerReadRepository;

        public GetCustomerByUserIdCommandHandler(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        public async Task<GetCustomerDto> Handle(GetCustomerByUserIdQueriesRequest request, CancellationToken cancellationToken)
        {
            GetCustomerDto customerDto = await _customerReadRepository.GetCustomerByUserNameAsync(request.Id);
            if (customerDto == null)
                throw new UserNotFoundException("Kullanıcı Bulunamadı");
            return customerDto;
        }
    }
}
