using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs.Address;
using API.Application_.DTOs.Menu;
using API.Application_.DTOs.Review;

namespace API.Application_.DTOs.Restaurant
{
    public class GetRestaurantDto
    {
        public string Id { get; set; }
        public string RestaurantName { get; set; }
        public string Address { get; set; }
        public string RestaurantPhoneNumber { get; set; }
        public string CuisineType { get; set; }
        public double AverageScore { get; set; }
        public List<GetRestaurantReviewDto> Reviews { get; set; }
        public List<GetMenuDto> Menus { get; set; }

        public AddressDto AddressDto { get; set; }
    }
}
