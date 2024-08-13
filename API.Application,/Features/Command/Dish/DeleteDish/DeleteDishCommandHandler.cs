using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs;
using API.Application_.Repositories.Dish;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application_.Features.Command.Dish.DeleteDish
{
    public class DeleteDishCommandHandler : IRequestHandler<DeleteDishCommandRequest, ResultDto>
    {
        readonly IDishWriteRepository _repository;

        public DeleteDishCommandHandler(IDishWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultDto> Handle(DeleteDishCommandRequest request, CancellationToken cancellationToken)
        {
            var dish = await _repository.Table.FirstOrDefaultAsync(x => x.Id == request.DishId);
            if (dish is null)
                return new() { Succeeded = false, Message = "Ürün bulunamadı" };

            _repository.Remove(dish);
            var result = await _repository.SaveAsync();
            if (result < 1)
                throw new Exception("Ürün silinirken bir hata meydana geldi");

            return new() { Succeeded = true };
        }
    }
}
