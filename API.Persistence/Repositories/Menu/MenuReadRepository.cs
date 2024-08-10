using API.Application_.Repositories.Dish;
using API.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.Repositories.Menu;

namespace API.Persistence.Repositories.Menu
{
    public class MenuReadRepository : ReadRepository<Domain.Entities.Menu>, IMenuReadRepository
    {
        public MenuReadRepository(APIDbContext context) : base(context)
        {
        }
    }
}
