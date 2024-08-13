using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs;
using API.Application_.Exceptions;
using API.Application_.Repositories.Restaurant;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application_.Features.Command.Restaurant.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommandRequest, ResultDto>
    {
        readonly IRestaurantWriteRepository _repository;

        public UpdateRestaurantCommandHandler(IRestaurantWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultDto> Handle(UpdateRestaurantCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Restaurant entity = await _repository.Table.FirstOrDefaultAsync(x => x.Id == request.Id);
            entity.RestaurantPhoneNumber = request.RestaurantPhoneNumber;
            entity.CuisineType = request.CuisineType;
            entity.Address = request.Address;
            entity.RestaurantName = request.RestaurantName;

            _repository.Update(entity);
            var result = await _repository.SaveAsync();

            if (result < 1)
                throw new UpdateException();

            return new() { Succeeded = true };
        }
    }
}
