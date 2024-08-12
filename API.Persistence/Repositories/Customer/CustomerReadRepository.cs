using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs.Customer;
using API.Application_.Repositories.Customer;
using API.Application_.Repositories.RestaurantOwner;
using API.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Repositories.Customer
{
    public class CustomerReadRepository : ReadRepository<Domain.Entities.Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(APIDbContext context) : base(context)
        {
        }

        public async Task<GetCustomerDto> GetCustomerAsync(string username)
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

            return customers;
        }

    }
}
