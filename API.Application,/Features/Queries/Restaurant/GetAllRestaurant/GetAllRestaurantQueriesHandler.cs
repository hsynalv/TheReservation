using API.Application_.DTOs.Address;
using API.Application_.DTOs.Dish;
using API.Application_.DTOs.Menu;
using API.Application_.DTOs.Restaurant;
using API.Application_.DTOs.Review;
using API.Application_.Repositories.Address;
using API.Application_.Repositories.Restaurant;
using MediatR;

namespace API.Application_.Features.Queries.Restaurant.GetAllRestaurant
{
    public class GetAllRestaurantQueriesHandler : IRequestHandler<GetAllRestaurantQueriesRequest, List<GetRestaurantDto>>
    {
        private readonly IRestaurantReadRepository _restaurantReadRepository;
        private readonly IAddressReadRepository _addressReadRepository;

        public GetAllRestaurantQueriesHandler(IRestaurantReadRepository repository, IAddressReadRepository addressReadRepository)
        {
            _restaurantReadRepository = repository;
            _addressReadRepository = addressReadRepository;
        }

        public Task<List<GetRestaurantDto>> Handle(GetAllRestaurantQueriesRequest request, CancellationToken cancellationToken)
        {
            var result =  _restaurantReadRepository.GetAll(false)
                .Select(x => new GetRestaurantDto()
                {
                    Address = x.Address,
                    CuisineType = x.CuisineType,
                    Id = x.Id,
                    RestaurantPhoneNumber = x.RestaurantPhoneNumber,
                    RestaurantName = x.RestaurantName,
                    AverageScore = x.AverageScore,
                    Reviews = x.Reviews.Select(r => new GetRestaurantReviewDto()
                    {
                        Comment = r.Comment,
                        CustomerName = r.Customer.Name + " " + r.Customer.Lastname,
                        Id = r.Id,
                        Rating = r.Rating
                    }).ToList(),
                    Menus = x.Menus.Select(m => new GetMenuDto()
                    {
                        Name = m.Name,
                        Id = m.Id,
                        Dishes = m.Dishes.Select(d => new GetDishDto()
                        {
                            Description = d.Description,
                            Id = d.Id,
                            Name = d.Name,
                            Price = d.Price,
                            PhotoUrl = d.PhotoUrl
                        }).ToList(),
                    }).ToList(),
                    
                }).ToList();

            result.ForEach(x => 
                x.AddressDto = _addressReadRepository.GetWhere(a => a.RestaurantId == x.Id)
                    .Select(ax => new AddressDto()
                {
                        State = ax.State,
                        City = ax.City,
                        PostalCode = ax.PostalCode,
                        Street = ax.Street,
                        Country = ax.Country
                }).Single());

            return Task.FromResult(result);

        }
    }
}
