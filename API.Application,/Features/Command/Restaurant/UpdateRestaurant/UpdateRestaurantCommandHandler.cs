using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs;
using API.Application_.Exceptions;
using API.Application_.Repositories.Address;
using API.Application_.Repositories.Restaurant;
using API.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application_.Features.Command.Restaurant.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommandRequest, ResultDto>
    {
        readonly IRestaurantWriteRepository _restaurantWriteRepository;
        private readonly IAddressWriteRepository _addressWriteRepository;

        public UpdateRestaurantCommandHandler(IRestaurantWriteRepository repository, IAddressWriteRepository addressWriteRepository)
        {
            _restaurantWriteRepository = repository;
            _addressWriteRepository = addressWriteRepository;
        }

        public async Task<ResultDto> Handle(UpdateRestaurantCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Restaurant restaurant = await _restaurantWriteRepository.Table.FirstOrDefaultAsync(x => x.Id == request.Id);
            restaurant.RestaurantPhoneNumber = request.RestaurantPhoneNumber;
            restaurant.CuisineType = request.CuisineType;
            restaurant.Address = request.Address;
            restaurant.RestaurantName = request.RestaurantName;

            Address address = _addressWriteRepository.Table.FirstOrDefault(x => x.RestaurantId == request.Id);
            address.City = request.AddressDto.City;
            address.PostalCode = request.AddressDto.PostalCode;
            address.State = request.AddressDto.State;
            address.Street = request.AddressDto.Street;
            address.Country = request.AddressDto.Country;
            _restaurantWriteRepository.Update(restaurant);
            _addressWriteRepository.Update(address);

            var result = await _restaurantWriteRepository.SaveAsync();


            if (result < 1)
                throw new UpdateException();

            return new() { Succeeded = true };
        }
    }
}
