using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs.Dish;
using API.Application_.DTOs.Menu;
using API.Application_.Repositories.Menu;
using MediatR;

namespace API.Application_.Features.Queries.Menu.GetAllMenuByRestaurant
{
    public class GetAllMenuByRestaurantQueriesHandler : IRequestHandler<GetAllMenuByRestaurantQueriesRequest, List<GetMenuDto>>
    {
        readonly IMenuReadRepository _repository;

        public GetAllMenuByRestaurantQueriesHandler(IMenuReadRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetMenuDto>> Handle(GetAllMenuByRestaurantQueriesRequest request, CancellationToken cancellationToken)
        {
            var list = _repository.GetWhere(x => x.RestaurantId == request.RestaurantId).Select(m => new GetMenuDto()
            {
                Id = m.Id,
                Name = m.Name,
                Dishes = m.Dishes.Select(d => new GetDishDto()
                {
                    Description = d.Description,
                    Id = d.Id,
                    Name = d.Name,
                    Price = d.Price,
                    PhotoUrl = d.PhotoUrl
                }).ToList(),
            }).ToList();

            return Task.FromResult(list);
        }
    }
}
