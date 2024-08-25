using API.Application_.DTOs.Customer;
using API.Application_.Exceptions;
using API.Application_.Repositories.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs.RestaurantOwner;
using API.Application_.Repositories.RestaurantOwner;

namespace API.Application_.Features.Queries.RestuarantOwner.GetRestaurantOwner
{
    public class GetRestaurantOwnerCommandHandler : IRequestHandler<GetRestaurantOwnerQueriesRequest, GetRestaurantOwnerDto>
    {
        readonly IRestaurantOwnerReadRepository _repository;

        public GetRestaurantOwnerCommandHandler(IRestaurantOwnerReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetRestaurantOwnerDto> Handle(GetRestaurantOwnerQueriesRequest request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetRestaurantOwnerAsync(request.UserName);
            return result;
        }
    }
}


