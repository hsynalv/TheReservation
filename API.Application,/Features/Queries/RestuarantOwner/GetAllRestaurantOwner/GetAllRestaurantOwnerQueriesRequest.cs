using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs.RestaurantOwner;
using MediatR;

namespace API.Application_.Features.Queries.RestuarantOwner.GetAllRestaurantOwner
{
    public class GetAllRestaurantOwnerQueriesRequest : IRequest<List<GetRestaurantOwnerDto>>
    {

    }
}
