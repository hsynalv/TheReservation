using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs.Dish;
using API.Application_.DTOs.Menu;
using API.Application_.Repositories.Menu;
using MediatR;

namespace API.Application_.Features.Queries.Menu.GetMenu
{
    public class GetMenuQueriesHandler : IRequestHandler<GetMenuQueriesRequest, GetMenuDto>
    {
        readonly IMenuReadRepository _repository;

        public GetMenuQueriesHandler(IMenuReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetMenuDto> Handle(GetMenuQueriesRequest request, CancellationToken cancellationToken)
        {
            var menu = await _repository.GetByIdAsync(request.MenuId, false);
            return new()
            {
                Id = menu.RestaurantId,
                Name = menu.Name,
                Dishes = menu.Dishes.Select(d => new GetDishDto()
                {
                    Description = d.Description,
                    Id = d.Id,
                    Name = d.Name,
                    Price = d.Price,
                    PhotoUrl = d.PhotoUrl
                }).ToList(),
            };
        }
    }
}
