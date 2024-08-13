using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs.Menu;
using API.Application_.DTOs.Restaurant;
using API.Application_.DTOs.Review;
using API.Application_.Repositories.Restaurant;
using API.Application_.Repositories.RestaurantOwner;
using API.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application_.Features.Queries.Restaurant.GetRestaurantByOwnerId
{
    public class GetRestaurantByOwnerIdQueriesHandler : IRequestHandler<GetRestaurantByOwnerIdQueriesRequest, GetRestaurantDto>
    {
        readonly IRestaurantReadRepository _repository;

        public GetRestaurantByOwnerIdQueriesHandler(IRestaurantReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetRestaurantDto> Handle(GetRestaurantByOwnerIdQueriesRequest request, CancellationToken cancellationToken)
        {


            var result = await _repository.Table.Where(x => x.OwnerId == request.RestaurantOwnerId).Select(r =>
                new GetRestaurantDto()
                {
                    Address = r.Address,
                    CuisineType = r.CuisineType,
                    Id = r.Id,
                    RestaurantPhoneNumber = r.RestaurantPhoneNumber,
                    RestaurantName = r.RestaurantName,
                    Reviews = r.Reviews.Select(re => new GetRestaurantReviewDto()
                    {
                        Comment = re.Comment,
                        CustomerName = re.Customer.Name + " " + re.Customer.Lastname,
                        Id = re.Id,
                        Rating = re.Rating
                    }).ToList(),
                    Menus = r.Menus.Select(m => new GetMenuDto()
                    {
                        Name = m.Name,
                        Id = m.Id
                    }).ToList()
                }).SingleAsync();

           
            return result;
        }
    }
}
