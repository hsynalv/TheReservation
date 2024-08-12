using API.Application_.DTOs.Customer;
using API.Application_.DTOs.RestaurantOwner;
using API.Application_.Repositories.RestaurantOwner;
using API.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Repositories.RestaurantOwner;

public class RestaurantOwnerReadRepository : ReadRepository<Domain.Entities.RestaurantOwner>, IRestaurantOwnerReadRepository
{
    public RestaurantOwnerReadRepository(APIDbContext context) : base(context)
    {

    }

    public async Task<GetRestaurantOwnerDto> GetRestaurantOwnerAsync(string username)
    {

        var restaurantOwner = await Table
            .Where(c => c.AppUser.UserName == username)
            .Select(c => new GetRestaurantOwnerDto()
            {
                Id = c.Id,
                UserName = c.AppUser.UserName,
                Email = c.AppUser.Email,
                ProfilePicture = c.ProfilePicture,
                LastName = c.LastName,
                Name = c.Name,
                BirthDay = c.BirthDate,
                PhoneNumber = c.AppUser.PhoneNumber
            })
            .FirstOrDefaultAsync();

        return restaurantOwner;
    }

    public async Task<List<GetRestaurantOwnerDto>> GetAllRestaurantOwnerAsync()
    {
        var restaurantOwnersList = await Table
            .Include(c => c.AppUser) // AppUser'ı sorguya dahil edin
            .Select(c => new GetRestaurantOwnerDto()
            {
                Id = c.Id,
                UserName = c.AppUser.UserName,
                Email = c.AppUser.Email,
                ProfilePicture = c.ProfilePicture,
                LastName = c.LastName,
                Name = c.Name,
                BirthDay = c.BirthDate,
                PhoneNumber = c.AppUser.PhoneNumber
            })
            .ToListAsync();

        return restaurantOwnersList;
    }
}