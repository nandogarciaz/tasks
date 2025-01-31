using task.Models;

namespace task.DTOs;

public class UserDto: BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public User UserDtoToUserEntity (UserDto user){
        return new User { Name = user.Name, Id = user.Id,} ;
    }
}
