using API.Application_.DTOs.RestaurantOwner;
using API.Application_.Repositories.RestaurantOwner;
using MediatR;

namespace API.Application_.Features.Queries.RestuarantOwner.GetAllRestaurantOwner;

public class GetAllRestaurantOwnerQueriesHandler : IRequestHandler<GetAllRestaurantOwnerQueriesRequest, List<GetRestaurantOwnerDto>>
{
    private readonly IRestaurantOwnerReadRepository _repository;

    public GetAllRestaurantOwnerQueriesHandler(IRestaurantOwnerReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetRestaurantOwnerDto>> Handle(GetAllRestaurantOwnerQueriesRequest request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAllRestaurantOwnerAsync();
        return result;
    }
}