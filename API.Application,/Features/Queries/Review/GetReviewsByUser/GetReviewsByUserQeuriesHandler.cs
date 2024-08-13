using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs.Review;
using API.Application_.Repositories.Review;
using MediatR;

namespace API.Application_.Features.Queries.Review.GetReviewsByUser
{
    public class GetReviewsByUserQeuriesHandler : IRequestHandler<GetReviewByUserQueriesRequest, List<GetUserReviewDto>>
    {
        readonly IReviewReadRepository _repository;

        public GetReviewsByUserQeuriesHandler(IReviewReadRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetUserReviewDto>> Handle(GetReviewByUserQueriesRequest request, CancellationToken cancellationToken)
        {
            List<GetUserReviewDto> list = _repository.GetWhere(x => x.Customer.AppUser.Id == request.Id)
                .Select(r =>  new GetUserReviewDto()
                {
                    Comment = r.Comment,
                    Rating = r.Rating,
                    Id = r.Id,
                    RestaurantName = r.Restaurant.RestaurantName
                }).ToList();

            return Task.FromResult(list);
        }
    }
}
