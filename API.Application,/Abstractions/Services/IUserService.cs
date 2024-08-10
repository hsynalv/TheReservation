using API.Application_.DTOs.User;

namespace API.Application_.Abstractions.Services;

public interface IUserService
{
    Task<CreateUserResponseDto> CreateAsync(CreateUserDto model);
}