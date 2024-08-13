using API.Application_.DTOs.Restaurant;
using API.Application_.DTOs.Review;
using API.Application_.Repositories.Restaurant;
using MediatR;

namespace API.Application_.Features.Queries.Restaurant.GetAllRestaurant
{
    public class GetAllRestaurantQueriesHandler : IRequestHandler<GetAllRestaurantQueriesRequest, List<GetRestaurantDto>>
    {
        private readonly IRestaurantReadRepository _repository;

        public GetAllRestaurantQueriesHandler(IRestaurantReadRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetRestaurantDto>> Handle(GetAllRestaurantQueriesRequest request, CancellationToken cancellationToken)
        {
            var result =  _repository.GetAll(false)
                .Select(x => new GetRestaurantDto()
                {
                    Address = x.Address,
                    CuisineType = x.CuisineType,
                    Id = x.Id,
                    RestaurantPhoneNumber = x.RestaurantPhoneNumber,
                    RestaurantName = x.RestaurantName,
                    Reviews = x.Reviews.Select(r => new GetRestaurantReviewDto()
                    {
                        Comment = r.Comment,
                        CustomerName = r.Customer.Name + " " + r.Customer.Lastname,
                        Id = r.Id,
                        Rating = r.Rating
                    }).ToList()
                }).ToList();

            return Task.FromResult(result);

        }
    }
}
