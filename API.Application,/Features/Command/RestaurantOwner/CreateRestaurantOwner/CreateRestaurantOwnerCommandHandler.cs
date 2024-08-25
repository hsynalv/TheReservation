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
        _repository.AddAsync(new Domain.Entities.RestaurantOwner()
        {
            CreatedDate = DateTime.UtcNow.ToLocalTime(),
            Id = request.Id,
            Name = request.Name,
            LastName = request.LastName,
            BirthDate = request.BirthDate
        });
        
        var result = await _repository.SaveAsync();
        
        if (result == 0)
            throw new Exception("Restoran Sahibi Eklenemedi");

        return new ResultDto(){ Succeeded = true};
    }
}