using API.Application_.Repositories;
using API.Application_.Repositories.Review;
using API.Persistence.Context;

namespace API.Persistence.Repositories.Review;

public class ReviewReadRepository : ReadRepository<Domain.Entity.Review>, IReviewReadRepository
{
    public ReviewReadRepository(APIDbContext context) : base(context)
    {
    }
}