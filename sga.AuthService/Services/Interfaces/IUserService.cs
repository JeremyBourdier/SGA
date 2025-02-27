using sga.AuthService.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AuthService.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO?> GetUserByIdAsync(int id);
        Task<bool> AddUserAsync(UserDTO userDto);
        Task<bool> UpdateUserAsync(int id, UserDTO userDto);
        Task<bool> DeleteUserAsync(int id);
    }
}
