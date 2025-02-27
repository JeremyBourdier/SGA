using sga.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AuthService.Repositories.Interfaces
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<Permission>> GetAllAsync();
        Task<Permission?> GetByIdAsync(int id);
        Task<bool> AddAsync(Permission permission);
        Task<bool> UpdateAsync(Permission permission);
        Task<bool> DeleteAsync(int id);
    }
}
