using API.Application_.DTOs;
using API.Application_.Repositories.Customer;
using MediatR;

namespace API.Application_.Features.Command.Customer.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, ResultDto>
{
    private readonly ICustomerWriteRepository _repository;

    public CreateCustomerCommandHandler(ICustomerWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultDto> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
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
        return new ResultDto(){Succeeded = true};
    }
}