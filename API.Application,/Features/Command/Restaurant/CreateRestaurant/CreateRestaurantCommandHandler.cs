using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs;
using API.Application_.Repositories.Restaurant;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Application_.Features.Command.Restaurant.CreateRestaurant
{
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommandRequest, ResultDto>
    {
        private readonly IRestaurantWriteRepository _repository;

        public CreateRestaurantCommandHandler(IRestaurantWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultDto> Handle(CreateRestaurantCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Restaurant entity = new()
            {
                Id = Guid.NewGuid().ToString(),
                RestaurantName = request.RestaurantName,
                Address = request.Address,
                RestaurantPhoneNumber = request.RestaurantPhoneNumber,
                CuisineType = request.CuisineType,
                OwnerId = request.OwnerId,
                CreatedDate = DateTime.UtcNow.ToLocalTime()
            };

            await _repository.AddAsync(entity);

            var result = await _repository.SaveAsync();

            if (result < 1)
                throw new Exception("Restaurant bilgileri eklenirken bir hata meydana geldi");

            return new() { Succeeded = true };
        }
    }
}
