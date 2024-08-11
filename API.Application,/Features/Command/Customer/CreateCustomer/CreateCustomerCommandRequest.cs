using MediatR;

namespace API.Application_.Features.Command.Customer.CreateCustomer;

public class CreateCustomerCommandRequest : IRequest<CreateCustomerCommandResponse>
{
    public string Id  { get; set; }
}