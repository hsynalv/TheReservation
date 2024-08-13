using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application_.DTOs.Dish
{
    public class GetDishDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PhotoUrl { get; set; } // Photo URL or Path
    }
}
