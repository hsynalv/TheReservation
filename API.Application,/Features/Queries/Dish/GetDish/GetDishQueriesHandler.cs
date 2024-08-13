using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs.Dish;
using API.Application_.Repositories.Dish;
using MediatR;

namespace API.Application_.Features.Queries.Dish.GetDish
{
    public class GetDishQueriesHandler : IRequestHandler<GetDishQueriesRequest, GetDishDto>
    {
        readonly IDishReadRepository _dishReadRepository;

        public GetDishQueriesHandler(IDishReadRepository dishReadRepository)
        {
            _dishReadRepository = dishReadRepository;
        }

        public async Task<GetDishDto> Handle(GetDishQueriesRequest request, CancellationToken cancellationToken)
        {
            var dish = await _dishReadRepository.GetByIdAsync(request.DishId);
            if (dish is null)
                throw new Exception("Ürün bulunamadı");

            GetDishDto result = new()
            {
                Description = dish.Description,
                Id = dish.Id,
                Name = dish.Name,
                PhotoUrl = dish.PhotoUrl,
                Price = dish.Price
            };

            return result;

        }
    }
}
