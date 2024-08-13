using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs.Restaurant;
using API.Application_.Repositories.Restaurant;
using MediatR;

namespace API.Application_.Features.Queries.Restaurant.GetRestaurantById
{
    public class GetRestaurantByIdQueriesHandler : IRequestHandler<GetRestaurantByIdQueriesRequest, GetRestaurantDto>
    {
        readonly IRestaurantReadRepository _repository;

        public GetRestaurantByIdQueriesHandler(IRestaurantReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetRestaurantDto> Handle(GetRestaurantByIdQueriesRequest request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id, false);

            if (entity is null)
                throw new Exception("Restaurant bulunamadı");


            return new()
            {
                Id = entity.Id,
                RestaurantPhoneNumber = entity.RestaurantPhoneNumber,
                CuisineType = entity.CuisineType,
                Address = entity.Address,
                RestaurantName = entity.RestaurantName
            };
        }
    }
}
