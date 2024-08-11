using API.Application_.Repositories.RestaurantOwner;
using MediatR;

namespace API.Application_.Features.Command.RestaurantOwner.CreateRestaurantOwner;

public class CreateRestaurantOwnerCommandHandler : IRequestHandler<CreateRestaurantOwnerCommandRequest, CreateRestaurantOwnerCommandResponse>
{
    private readonly IRestaurantOwnerWriteRepository _repository;

    public CreateRestaurantOwnerCommandHandler(IRestaurantOwnerWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateRestaurantOwnerCommandResponse> Handle(CreateRestaurantOwnerCommandRequest request, CancellationToken cancellationToken)
    {
        _repository.Table.Add(new(){Id = request.Id, CreatedDate = DateTime.UtcNow.ToLocalTime()});
        

        try
        {
            var result = await _repository.SaveAsync();
        }
        catch (Exception ex)
        {
            // Inner exception'ı kontrol et
            var innerException = ex.InnerException?.Message;
            Console.WriteLine(innerException);
            throw;
        }


        //if (result == 0)
        //    throw new Exception("Müşteri Eklenemedi");
        return new CreateRestaurantOwnerCommandResponse(){Succeeded = true};
    }
}