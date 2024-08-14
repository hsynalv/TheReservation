using API.Application_.DTOs;
using MediatR;

namespace API.Application_.Features.Command.AppUser.ChangePhoneNumber;

public class ChangePhoneNumberCommandRequest : IRequest<ResultDto>
{
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
}