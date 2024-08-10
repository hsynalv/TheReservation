using API.Application_.Abstractions.Services;
using API.Application_.DTOs.User;
using API.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace API.Persistence.Services;

public class UserService : IUserService
{
    readonly UserManager<AppUser> _userManager;
    public UserService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<CreateUserResponseDto> CreateAsync(CreateUserDto model)
    {
        IdentityResult result = await _userManager.CreateAsync(new()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = model.UserName,
            Email = model.Email,
        }, model.Password);

        CreateUserResponseDto response = new() { Succeeded = result.Succeeded };

        if (result.Succeeded)
            response.Message = "Kullanıcı başarıyla oluşturulmuştur.";
        else
            foreach (var error in result.Errors)
                response.Message += $"{error.Code} - {error.Description}\n";

        return response;
    }
}