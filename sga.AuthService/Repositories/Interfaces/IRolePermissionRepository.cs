using sga.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AuthService.Repositories.Interfaces
{
    public interface IRolePermissionRepository
    {
        Task<IEnumerable<RolePermission>> GetAllAsync();
        Task<RolePermission?> GetByIdsAsync(int roleId, int permissionId);
        Task<bool> AddAsync(RolePermission entity);
        Task<bool> DeleteAsync(int roleId, int permissionId);
    }
}
