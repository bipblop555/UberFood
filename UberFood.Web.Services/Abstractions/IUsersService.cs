using UberFood.Web.Services.Services.Dtos;

namespace UberFood.Web.Services.Abstractions;

public interface IUsersService
{
    Task<IEnumerable<UserDto>> GetUsersAsync();
    Task<UserDto> GetUserByIdAsync(Guid id);
    Task CreateUserAsync(UserDto userDto);
    Task UpdateUserAsync(Guid id, UserDto userDto);
    Task DeleteUserAsync(Guid id);
}
