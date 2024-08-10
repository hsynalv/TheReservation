using API.Application_.Repositories.Menu;
using API.Persistence.Context;

namespace API.Persistence.Repositories.Menu;

public class MenuWriteRepository : WriteRepository<Domain.Entities.Menu>, IMenuWriteRepository
{
    public MenuWriteRepository(APIDbContext context) : base(context)
    {
    }
}