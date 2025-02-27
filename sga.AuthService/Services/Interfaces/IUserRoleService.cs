using sga.AuthService.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AuthService.Services.Interfaces
{
    public interface IUserRoleService
    {
        Task<IEnumerable<UserRoleDTO>> GetAllAsync();
        Task<UserRoleDTO> GetByIdAsync(int userId, int roleId);
        Task AddAsync(UserRoleDTO userRoleDto);
        Task DeleteAsync(int userId, int roleId);
    }
}
