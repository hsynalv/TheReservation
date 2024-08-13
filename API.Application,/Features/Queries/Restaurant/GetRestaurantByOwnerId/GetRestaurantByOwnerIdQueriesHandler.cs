using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs.Restaurant;
using API.Application_.Repositories.Restaurant;
using API.Application_.Repositories.RestaurantOwner;
using API.Domain.Entities;
using MediatR;

namespace API.Application_.Features.Queries.Restaurant.GetRestaurantByOwnerId
{
    public class GetRestaurantByOwnerIdQueriesHandler : IRequestHandler<GetRestaurantByOwnerIdQueriesRequest, GetRestaurantDto>
    {
        readonly IRestaurantReadRepository _repository;

        public GetRestaurantByOwnerIdQueriesHandler(IRestaurantReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetRestaurantDto> Handle(GetRestaurantByOwnerIdQueriesRequest request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetSingleAsync(x => x.OwnerId == request.RestaurantOwnerId);

            GetRestaurantDto response = new()
            {
                Id = result.Id,
                RestaurantName = result.RestaurantName,
                RestaurantPhoneNumber = result.RestaurantPhoneNumber,
                CuisineType = result.CuisineType,
                Address = result.Address
            };
            return response;
        }
    }
}
