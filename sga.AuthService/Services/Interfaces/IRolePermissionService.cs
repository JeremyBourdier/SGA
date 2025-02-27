using sga.AuthService.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AuthService.Services.Interfaces
{
    public interface IRolePermissionService
    {
        Task<IEnumerable<RolePermissionDTO>> GetAllAsync();
        Task<RolePermissionDTO?> GetByIdsAsync(int roleId, int permissionId);
        Task<bool> AddAsync(RolePermissionDTO dto);
        Task<bool> DeleteAsync(int roleId, int permissionId);
    }
}
