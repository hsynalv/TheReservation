using System.Reflection.Metadata.Ecma335;
using API.Application_.Abstractions.Services;
using API.Application_.DTOs.User;
using API.Application_.Exceptions;
using API.Application_.Helpers;
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
            Id = model.id,
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

    public async Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
    {
        user.RefreshToken = refreshToken;
        user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate).ToLocalTime();
        IdentityResult result = await _userManager.UpdateAsync(user);
    }

    public async Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
    {
        AppUser user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            resetToken = resetToken.UrlDecode();
            IdentityResult result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
            if (result.Succeeded)
                await _userManager.UpdateSecurityStampAsync(user);
            else
                throw new PasswordChangeFailedException();
        }
    }

    public async Task<bool> ChangePassword(AppUser user, string currentPassword, string newPassword)
    {
       bool checkPassword = await _userManager.CheckPasswordAsync(user, currentPassword);
       if (!checkPassword)
           throw new Exception("Mevcut Şifrenizi Hatalı Girdiniz...");

       IdentityResult result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
       
       if (result.Succeeded)
           return true;
       return false;
    }

    public async Task<AppUser> GetUser(string username)
    {
        AppUser user = await _userManager.FindByNameAsync(username);
        if (user == null)
            throw new UserNotFoundException("Kullanıcı adı bulunamadı");
        return user;
    }
}
