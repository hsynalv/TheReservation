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
        _repository.AddAsync(new Domain.Entities.Customer()
        {
            Id = request.Id,
            BirthDate = request.BirthDate,
            CreatedDate = DateTime.UtcNow.ToLocalTime(),
            Name = request.Name,
            Lastname = request.LastName
        });
        
        var result = await _repository.SaveAsync();


        if (result == 0) 
            throw new Exception("Müşteri Eklenemedi");
        return new ResultDto(){Succeeded = true};
    }
}