using sga.AuthService.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AuthService.Services.Interfaces
{
    public interface IPermissionService
    {
        Task<IEnumerable<PermissionDTO>> GetAllPermissionsAsync();
        Task<PermissionDTO?> GetPermissionByIdAsync(int id);
        Task<bool> AddPermissionAsync(PermissionDTO dto);
        Task<bool> UpdatePermissionAsync(int id, PermissionDTO dto);
        Task<bool> DeletePermissionAsync(int id);
    }
}

