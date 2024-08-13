using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs;
using API.Application_.Repositories.Menu;
using API.Application_.Repositories.Restaurant;
using MediatR;

namespace API.Application_.Features.Command.Menu.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommandRequest, ResultDto>
    {
        readonly IMenuWriteRepository _menuWriteRepository;
        readonly IRestaurantReadRepository _restaurantReadRepository;

        public CreateMenuCommandHandler(IMenuWriteRepository repository, IRestaurantReadRepository restaurantReadRepository)
        {
            _menuWriteRepository = repository;
            _restaurantReadRepository = restaurantReadRepository;
        }

        public async Task<ResultDto> Handle(CreateMenuCommandRequest request, CancellationToken cancellationToken)
        {

            var restaurant = await _restaurantReadRepository.GetByIdAsync(request.RestaurantId, false);
            if (restaurant is null)
                return new() { Succeeded = false, Message = "Restoran bulunamadı" };

            Domain.Entities.Menu entity = new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                CreatedDate = DateTime.UtcNow.ToLocalTime(),
                RestaurantId = request.RestaurantId
            };

            await _menuWriteRepository.AddAsync(entity);
            var result = await _menuWriteRepository.SaveAsync();

            if (result < 1)
               throw new Exception("Menu Eklenirken bir hata meydana geldi");

            return new() { Succeeded = true };
        }
    }
}
