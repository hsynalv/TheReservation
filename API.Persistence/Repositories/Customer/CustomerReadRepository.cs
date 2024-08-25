using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs.Customer;
using API.Application_.DTOs.Review;
using API.Application_.Repositories.Customer;
using API.Application_.Repositories.RestaurantOwner;
using API.Application_.Repositories.Review;
using API.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Repositories.Customer
{
    public class CustomerReadRepository : ReadRepository<Domain.Entities.Customer>, ICustomerReadRepository
    {
        private readonly IReviewReadRepository _reviewReadRepository;
        public CustomerReadRepository(APIDbContext context, IReviewReadRepository reviewReadRepository) : base(context)
        {
            _reviewReadRepository = reviewReadRepository;
        }

        public async Task<GetCustomerDto> GetCustomerByUserNameAsync(string username)
        {

            var customer = await Table
                .Where(c => c.AppUser.UserName == username)
                .Select(c => new GetCustomerDto()
            {
                Id = c.Id,
                UserName = c.AppUser.UserName,
                Email = c.AppUser.Email,
                ProfilePicture = c.ProfilePicture,
                Score = c.Score,
                LastName = c.Lastname,
                Name = c.Name,
                BirthDay = c.BirthDate,
                PhoneNumber = c.AppUser.PhoneNumber
            })
                .FirstOrDefaultAsync();

            customer.Reviews = _reviewReadRepository.GetWhere(r => r.UserId == customer.Id).Select(re =>
                new GetUserReviewDto()
                {
                    RestaurantName = re.Restaurant.RestaurantName,
                    Comment = re.Comment,
                    Rating = re.Rating,
                    Id = re.Id
                }).ToList();

            return customer;
        }

        public async Task<GetCustomerDto> GetCustomerByUserIdAsync(string Id)
        {
            var customer = await Table.Where(x => x.AppUser.Id == Id)
                .Select(c => new GetCustomerDto()
                {
                    Id = c.Id,
                    UserName = c.AppUser.UserName,
                    Email = c.AppUser.Email,
                    ProfilePicture = c.ProfilePicture,
                    Score = c.Score,
                    LastName = c.Lastname,
                    Name = c.Name,
                    BirthDay = c.BirthDate,
                    PhoneNumber = c.AppUser.PhoneNumber
                })
                .FirstOrDefaultAsync();

            customer.Reviews = _reviewReadRepository.GetWhere(r => r.UserId == customer.Id).Select(re =>
                new GetUserReviewDto()
                {
                    RestaurantName = re.Restaurant.RestaurantName,
                    Comment = re.Comment,
                    Rating = re.Rating,
                    Id = re.Id
                }).ToList();
            //TODO: Hatalı
            return customer;
        }

        public async Task<List<GetCustomerDto>> GetAllCustomersAsync()
        {
            var customers = await Table
                .Include(c => c.AppUser) // AppUser'ı sorguya dahil edin
                .Select(c => new GetCustomerDto
                {
                    Id = c.Id,
                    UserName = c.AppUser.UserName,
                    Email = c.AppUser.Email,
                    ProfilePicture = c.ProfilePicture,
                    Score = c.Score,
                    LastName = c.Lastname,
                    Name = c.Name,
                    BirthDay = c.BirthDate,
                    PhoneNumber = c.AppUser.PhoneNumber
                })
                .ToListAsync();

            customers.ForEach(x => x.Reviews = _reviewReadRepository.GetWhere(r => r.UserId == x.Id).Select(re => new GetUserReviewDto()
            {
                RestaurantName = re.Restaurant.RestaurantName,
                Comment = re.Comment,
                Rating = re.Rating,
                Id = re.Id
            }).ToList());

            return customers;
        }

    }
}
