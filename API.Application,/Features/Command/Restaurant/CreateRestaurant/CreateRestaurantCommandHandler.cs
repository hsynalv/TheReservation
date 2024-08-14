using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs;
using API.Application_.Repositories.Address;
using API.Application_.Repositories.Restaurant;
using API.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Application_.Features.Command.Restaurant.CreateRestaurant
{
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommandRequest, ResultDto>
    {
        private readonly IRestaurantWriteRepository _restaurantWriteRepository;
        readonly IAddressWriteRepository _addressWriteRepository;

        public CreateRestaurantCommandHandler(IRestaurantWriteRepository repository, IAddressWriteRepository addressWriteRepository)
        {
            _restaurantWriteRepository = repository;
            _addressWriteRepository = addressWriteRepository;
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
                CreatedDate = DateTime.UtcNow.ToLocalTime(),
                
            };

            Address address = new()
            {
                CreatedDate = DateTime.UtcNow.ToLocalTime(),
                RestaurantId = entity.Id,
                Restaurant = entity,
                Id = Guid.NewGuid().ToString(),
                City = request.AddressDto.City,
                PostalCode = request.AddressDto.PostalCode,
                State = request.AddressDto.State,
                Street = request.AddressDto.Street,
                Country = request.AddressDto.Country

            }; 

            await _restaurantWriteRepository.AddAsync(entity);
            await _addressWriteRepository.AddAsync(address);


            var result = await _restaurantWriteRepository.SaveAsync();


            if (result < 1)
                throw new Exception("Restaurant bilgileri eklenirken bir hata meydana geldi");

            return new() { Succeeded = true };
        }
    }
}
