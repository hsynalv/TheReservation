﻿using System;
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
using API.Application_.Repositories.RestaurantOwner;
using API.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application_.Features.Queries.Restaurant.GetRestaurantByOwnerId
{
    public class GetRestaurantByOwnerIdQueriesHandler : IRequestHandler<GetRestaurantByOwnerIdQueriesRequest, GetRestaurantDto>
    {
        readonly IRestaurantReadRepository _restaurantReadRepository;
        readonly IAddressReadRepository _addressReadRepository;

        public GetRestaurantByOwnerIdQueriesHandler(IRestaurantReadRepository repository, IAddressReadRepository addressReadRepository)
        {
            _restaurantReadRepository = repository;
            _addressReadRepository = addressReadRepository;
        }

        public async Task<GetRestaurantDto> Handle(GetRestaurantByOwnerIdQueriesRequest request, CancellationToken cancellationToken)
        {


            var result = await _restaurantReadRepository.Table.Where(x => x.OwnerId == request.RestaurantOwnerId).Select(r =>
                new GetRestaurantDto()
                {
                    Address = r.Address,
                    CuisineType = r.CuisineType,
                    Id = r.Id,
                    RestaurantPhoneNumber = r.RestaurantPhoneNumber,
                    AverageScore = r.AverageScore,
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
                        Id = m.Id,
                        Dishes = m.Dishes.Select(d => new GetDishDto()
                        {
                            Description = d.Description,
                            Id = d.Id,
                            Name = d.Name,
                            Price = d.Price,
                            PhotoUrl = d.PhotoUrl
                        }).ToList(),
                    }).ToList()
                }).SingleAsync();

            result.AddressDto = _addressReadRepository.GetWhere(x => x.RestaurantId == result.Id).Select(a =>
                new AddressDto()
                {
                    State = a.State,
                    City = a.City,
                    PostalCode = a.PostalCode,
                    Street = a.Street,
                    Country = a.Country
                }).Single();

           
            return result;
        }
    }
}
