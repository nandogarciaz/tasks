using Microsoft.EntityFrameworkCore;
using task.Data;
using task.DTOs;
using task.Models;

namespace task.Service;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        return await _context.Users
            .Include(o => o.Tasks)
            .Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name
            })
            .ToListAsync();
    }

    public async Task<UserDto?> GetUserByIdAsync(int id)
    {
        var user = await _context.Users
            .Include(o => o.Tasks)
            .FirstAsync(x => x.Id == id);
        if (user == null) return null;

        return new UserDto { 
            Id = user.Id, 
            Name = user.Name
        };
    }

    public async Task<UserDto> CreateUserAsync(UserDto userDto)
    {
        var user = new User { Name = userDto.Name };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new UserDto { Id = user.Id, Name = user.Name };
    }

    public async Task<bool> UpdateUserAsync(int id, UserDto userDto)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return false;

        user.Name = userDto.Name;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
}
