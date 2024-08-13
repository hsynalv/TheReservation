using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs;
using API.Application_.Repositories.Dish;
using API.Application_.Repositories.Menu;
using MediatR;

namespace API.Application_.Features.Command.Dish.CreateDish
{
    public class CreateDishCommandHandler : IRequestHandler<CreateDishCommandRequest, ResultDto> 
    {
        readonly IDishWriteRepository _dishRepository;
        readonly IMenuReadRepository _menuReadRepository;

        public CreateDishCommandHandler(IDishWriteRepository dishRepository, IMenuReadRepository menuReadRepository)
        {
            _dishRepository = dishRepository;
            _menuReadRepository = menuReadRepository;
        }

        public async Task<ResultDto> Handle(CreateDishCommandRequest request, CancellationToken cancellationToken)
        {
            var menu = await _menuReadRepository.GetByIdAsync(request.MenuId);
            if (menu is null)
                return new() { Message = "Menu Bulunamadı", Succeeded = false };

            Domain.Entities.Dish dish = new()
            {
                Id = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.UtcNow.ToLocalTime(),
                Name = request.Name,
                Description = request.Description,
                MenuId = request.MenuId,
                Price = request.Price,
                PhotoUrl = request.PhotoUrl
            };

            _dishRepository.AddAsync(dish);
            var result = await _dishRepository.SaveAsync();
            if (result < 1)
                throw new Exception("Ürün oluşturulurken bir hata meydana geldi");
            return new() { Succeeded = true };
        }
    }
}
