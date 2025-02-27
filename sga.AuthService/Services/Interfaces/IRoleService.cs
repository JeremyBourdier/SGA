using sga.AuthService.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AuthService.Services.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDTO>> GetAllRolesAsync();
        Task<RoleDTO?> GetRoleByIdAsync(int id);
        Task<bool> AddRoleAsync(RoleDTO roleDto);
        Task<bool> UpdateRoleAsync(int id, RoleDTO roleDto);
        Task<bool> DeleteRoleAsync(int id);
    }
}
