using task.DTOs;

namespace task.Service;

public interface IUserService 
{
    Task<IEnumerable<UserDto>> GetUsersAsync();
    Task<UserDto?> GetUserByIdAsync(int id);
    Task<UserDto> CreateUserAsync(UserDto userDto);
    Task<bool> UpdateUserAsync(int id, UserDto userDto);
    Task<bool> DeleteUserAsync(int id);
}