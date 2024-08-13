using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs.Menu;
using API.Application_.DTOs.Restaurant;
using API.Application_.DTOs.Review;
using API.Application_.Repositories.Restaurant;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application_.Features.Queries.Restaurant.GetRestaurantById
{
    public class GetRestaurantByIdQueriesHandler : IRequestHandler<GetRestaurantByIdQueriesRequest, GetRestaurantDto>
    {
        readonly IRestaurantReadRepository _repository;

        public GetRestaurantByIdQueriesHandler(IRestaurantReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetRestaurantDto> Handle(GetRestaurantByIdQueriesRequest request, CancellationToken cancellationToken)
        {
            var entity = await  _repository.Table.Where(x => x.Id == request.Id).Select(r => new GetRestaurantDto()
            {
                Reviews = r.Reviews.Select(x => new GetRestaurantReviewDto()
                {
                    Comment = x.Comment,
                    CustomerName = x.Customer.Name + " " + x.Customer.Lastname,
                    Id = x.Id,
                    Rating = x.Rating
                }).ToList(),
                Address = r.Address,
                CuisineType = r.CuisineType,
                Id = r.Id,
                RestaurantPhoneNumber = r.RestaurantPhoneNumber,
                RestaurantName = r.RestaurantName,
                Menus = r.Menus.Select(m => new GetMenuDto()
                {
                    Name = m.Name,
                    Id = m.Id
                }).ToList()
            }).SingleAsync();

            if (entity is null)
                throw new Exception("Restaurant bulunamadı");

            return entity;
        }
    }
}
