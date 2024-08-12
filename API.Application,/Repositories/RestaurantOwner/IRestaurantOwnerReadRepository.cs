using API.Application_.DTOs.RestaurantOwner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application_.Repositories.RestaurantOwner
{

    public interface IRestaurantOwnerReadRepository : IReadRepository<Domain.Entities.RestaurantOwner>
    {
        Task<GetRestaurantOwnerDto> GetRestaurantOwnerAsync(string username);
        Task<List<GetRestaurantOwnerDto>> GetAllRestaurantOwnerAsync();
    }
}
