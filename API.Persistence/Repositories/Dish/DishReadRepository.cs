using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.Repositories.Dish;
using API.Persistence.Context;

namespace API.Persistence.Repositories.Dish
{
    public class DishReadRepository : ReadRepository<Domain.Entity.Dish>, IDishReadRepository
    {
        public DishReadRepository(APIDbContext context) : base(context)
        {
        }
    }
}
