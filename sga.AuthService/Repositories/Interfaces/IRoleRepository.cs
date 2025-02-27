using sga.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AuthService.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role?> GetByIdAsync(int id);
        Task<bool> AddAsync(Role role);
        Task<bool> UpdateAsync(Role role);
        Task<bool> DeleteAsync(int id);
    }
}
