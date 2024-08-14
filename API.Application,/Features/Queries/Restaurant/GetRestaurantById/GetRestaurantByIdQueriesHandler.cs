using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs.Address;
using API.Application_.DTOs.Dish;
using API.Application_.DTOs.Menu;
using API.Application_.DTOs.Restaurant;
using API.Application_.DTOs.Review;
using API.Application_.Repositories.Address;
using API.Application_.Repositories.Restaurant;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application_.Features.Queries.Restaurant.GetRestaurantById
{
    public class GetRestaurantByIdQueriesHandler : IRequestHandler<GetRestaurantByIdQueriesRequest, GetRestaurantDto>
    {
        readonly IRestaurantReadRepository _restaurantReadRepository;
        readonly IAddressReadRepository _addressReadRepository;

        public GetRestaurantByIdQueriesHandler(IRestaurantReadRepository repository, IAddressReadRepository addressReadRepository)
        {
            _restaurantReadRepository = repository;
            _addressReadRepository = addressReadRepository;
        }

        public async Task<GetRestaurantDto> Handle(GetRestaurantByIdQueriesRequest request, CancellationToken cancellationToken)
        {
            var entity = await  _restaurantReadRepository.Table.Where(x => x.Id == request.Id).Select(r => new GetRestaurantDto()
            {
                
                Address = r.Address,
                CuisineType = r.CuisineType,
                AverageScore = r.AverageScore,
                Id = r.Id,
                RestaurantPhoneNumber = r.RestaurantPhoneNumber,
                RestaurantName = r.RestaurantName,
                Menus = r.Menus.Select(m => new GetMenuDto()
                {
                    Name = m.Name,
                    Id = m.Id,
                    Dishes = m.Dishes.Select(d => new GetDishDto()
                    {
                        Description = d.Description,
                        Id = d.Id,
                        Name = d.Name,
                        Price = d.Price,
                        PhotoUrl = d.PhotoUrl
                    }).ToList(),
                }).ToList(),
                Reviews = r.Reviews.Select(x => new GetRestaurantReviewDto()
                {
                    Comment = x.Comment,
                    CustomerName = x.Customer.Name + " " + x.Customer.Lastname,
                    Id = x.Id,
                    Rating = x.Rating
                }).ToList()

            }).SingleAsync();

            entity.AddressDto = _addressReadRepository.GetWhere(x => x.RestaurantId == entity.Id).Select(a =>
                new AddressDto()
                {
                    State = a.State,
                    City = a.City,
                    PostalCode = a.PostalCode,
                    Street = a.Street,
                    Country = a.Country
                }).Single();

            if (entity is null)
                throw new Exception("Restaurant bulunamadı");

            return entity;
        }
    }
}
