using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs;
using API.Application_.Exceptions;
using API.Application_.Repositories.Dish;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application_.Features.Command.Dish.UpdateDish
{
    public class UpdateDishCommandHandler : IRequestHandler<UpdateDishCommandRequest, ResultDto>
    {
        readonly IDishWriteRepository _dishRepository;

        public UpdateDishCommandHandler(IDishWriteRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }

        public async Task<ResultDto> Handle(UpdateDishCommandRequest request, CancellationToken cancellationToken)
        {
            var dish = await _dishRepository.Table.FirstOrDefaultAsync(x => x.Id == request.dishId);
            if (dish is null)
                return new() { Succeeded = false, Message = "Ürün bulunamadı" };

            dish.Description = request.Description;
            dish.Name = request.Name;
            dish.PhotoUrl = request.PhotoUrl;
            dish.Price = request.Price;
            dish.PhotoUrl = request.PhotoUrl;

            _dishRepository.Update(dish);
            var result = await _dishRepository.SaveAsync();

            if (result < 1)
                throw new UpdateException();
            return new() { Succeeded = true };
        }
    }
}
