﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs;
using API.Application_.Exceptions;
using API.Application_.Repositories.RestaurantOwner;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application_.Features.Command.RestaurantOwner.UpdateRestaurantOwner
{
    public class UpdateRestaurantOwnerCommandHandler : IRequestHandler<UpdateRestaurantOwnerCommandRequest, ResultDto>
    {
        private readonly IRestaurantOwnerWriteRepository _repository;

        public UpdateRestaurantOwnerCommandHandler(IRestaurantOwnerWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultDto> Handle(UpdateRestaurantOwnerCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.RestaurantOwner entity =
                await _repository.Table.FirstOrDefaultAsync(x => x.AppUser.UserName == request.username);

            entity.LastName = request.LastName;
            entity.Name = request.Name;
            entity.UpdatedDate = DateTime.UtcNow.ToLocalTime();

            _repository.Update(entity);

            var result = await _repository.SaveAsync();

            if (result < 1)
                throw new UpdateException();

            return new() { Succeeded = true };
        }
    }

    public class UpdateRestaurantOwnerCommandRequest : IRequest<ResultDto>
    {
        public string username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        
    }

}
