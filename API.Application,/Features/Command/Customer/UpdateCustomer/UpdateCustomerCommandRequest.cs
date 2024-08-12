using MediatR;

namespace API.Application_.Features.Command.Customer.UpdateCustomer;

public class UpdateCustomerCommandRequest : IRequest<UpdateCustomerCommandResponse>
{
    public string username { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

        
}