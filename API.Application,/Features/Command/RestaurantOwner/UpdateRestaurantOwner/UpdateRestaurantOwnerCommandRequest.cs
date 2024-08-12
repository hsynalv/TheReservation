using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs;
using MediatR;

namespace API.Application_.Features.Command.RestaurantOwner.UpdateRestaurantOwner
{
    public class UpdateRestaurantOwnerCommandRequest : IRequest<ResultDto>
    {
        public string username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        
    }

}
