using API.Application_.Abstractions.Services;
using API.Application_.DTOs.User;
using API.Application_.Exceptions;
using API.Application_.Features.Command.Customer.CreateCustomer;
using API.Application_.Features.Command.RestaurantOwner.CreateRestaurantOwner;
using API.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace API.Application_.Features.Command.AppUser.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    readonly IUserService _userService;
    readonly IMediator _mediator; 

    public CreateUserCommandHandler(IUserService userService, IMediator mediator)
    {
        _userService = userService;
        _mediator = mediator;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        CreateUserDto userDto = new()
        {
            id = Guid.NewGuid().ToString(),
            Email = request.Email,
            Password = request.Password,
            UserName = request.UserName
        };

        CreateUserResponseDto response = await _userService.CreateAsync(userDto);

        if(response.Succeeded)
        {
            if (request.UserType == true) // Customer
            {
                var customer = new Domain.Entities.Customer { Id = userDto.id};
                var result = await _mediator.Send(new CreateCustomerCommandRequest() { Id = userDto.id });

                if (!result.Succeeded)
                    throw new Exception("Müşteri Oluşturulamadı");
            }
            else
            {
                var result = await _mediator.Send(new CreateRestaurantOwnerCommandRequest() { Id = userDto.id });

                if (!result.Succeeded)
                    throw new Exception("Müşteri Oluşturulamadı");
            }

            return new CreateUserCommandResponse
            {
                Message = response.Message,
                Succeeded = response.Succeeded
            };

        }

        throw new Exception("Kullanıcı Oluşturulurken bir hata meydana geldi");

    }
}