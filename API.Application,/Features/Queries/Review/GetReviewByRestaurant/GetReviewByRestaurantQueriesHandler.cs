using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs.Review;
using API.Application_.Repositories.Review;
using MediatR;

namespace API.Application_.Features.Queries.Review.GetReviewByRestaurant
{
    public class GetReviewByRestaurantQueriesHandler : IRequestHandler<GetReviewByRestaurantQueriesRequest,List<GetRestaurantReviewDto> >
    {
        readonly IReviewReadRepository _repository;

        public GetReviewByRestaurantQueriesHandler(IReviewReadRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetRestaurantReviewDto>> Handle(GetReviewByRestaurantQueriesRequest request, CancellationToken cancellationToken)
        {
            List<GetRestaurantReviewDto> list = _repository.GetWhere(x => x.Restaurant.Id == request.RestaurantId)
                .Select(r => new GetRestaurantReviewDto()
                {
                    Comment = r.Comment,
                    CustomerName = r.Customer.Name + " " + r.Customer.Lastname,
                    Id = r.Id,
                    Rating = r.Rating
                }).ToList();

            return Task.FromResult(list);
        }
    }
}
