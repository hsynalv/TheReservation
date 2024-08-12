using API.Application_.DTOs;
using API.Application_.Repositories.RestaurantOwner;
using MediatR;

namespace API.Application_.Features.Command.RestaurantOwner.CreateRestaurantOwner;

public class CreateRestaurantOwnerCommandHandler : IRequestHandler<CreateRestaurantOwnerCommandRequest, ResultDto>
{
    private readonly IRestaurantOwnerWriteRepository _repository;

    public CreateRestaurantOwnerCommandHandler(IRestaurantOwnerWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultDto> Handle(CreateRestaurantOwnerCommandRequest request, CancellationToken cancellationToken)
    {
        _repository.Table.Add(new(){Id = request.Id, CreatedDate = DateTime.UtcNow.ToLocalTime()});
        
        var result = await _repository.SaveAsync();
        
        if (result == 0)
            throw new Exception("Restoran Sahibi Eklenemedi");

        return new ResultDto(){ Succeeded = true};
    }
}