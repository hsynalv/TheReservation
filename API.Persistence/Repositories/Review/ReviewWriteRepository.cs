using API.Application_.Repositories;
using API.Application_.Repositories.Review;
using API.Persistence.Context;

namespace API.Persistence.Repositories.Review
{
    public class ReviewWriteRepository: WriteRepository<Domain.Entity.Review>, IReviewWriteRepository
    {
        public ReviewWriteRepository(APIDbContext context) : base(context)
        {
        }
    }
}
