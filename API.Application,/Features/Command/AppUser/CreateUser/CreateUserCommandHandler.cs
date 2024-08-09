using API.Application_.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace API.Application_.Features.Command.AppUser.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    readonly UserManager<Domain.Entity.Identity.AppUser> _userManager;

    public CreateUserCommandHandler(UserManager<Domain.Entity.Identity.AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        IdentityResult result = await _userManager.CreateAsync(new()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = request.UserName,
            Email = request.Email,
        }, request.Password);

        if (result.Succeeded)
        {
            return new()
            {
                Succeeded = true,
                Message = "Kullanıcı başarıyla oluşturuldu..."
            };
        }

        throw new UserCreateFailedException();
    }
}