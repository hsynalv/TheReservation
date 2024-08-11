using API.Application_.DTOs.User;
using API.Domain.Entities.Identity;

namespace API.Application_.Abstractions.Services;

public interface IUserService
{
    Task<CreateUserResponseDto> CreateAsync(CreateUserDto model);
    Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
    Task UpdatePasswordAsync(string userId, string resetToken, string newPassword);
    Task<bool> ChangePassword(AppUser user, string currentPassword, string newPassword);
    Task<AppUser> GetUser(string username);
}