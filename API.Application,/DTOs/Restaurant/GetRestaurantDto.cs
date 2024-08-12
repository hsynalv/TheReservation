using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application_.DTOs.Restaurant
{
    public class GetRestaurantDto
    {
        public string RestaurantName { get; set; }
        public string Address { get; set; }
        public string RestaurantPhoneNumber { get; set; }
        public string CuisineType { get; set; }
    }
}
