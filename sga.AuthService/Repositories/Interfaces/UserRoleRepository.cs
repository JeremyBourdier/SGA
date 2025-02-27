using sga.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AuthService.Repositories.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<IEnumerable<UserRole>> GetAllAsync();
        Task<UserRole> GetByIdAsync(int userId, int roleId);
        Task AddAsync(UserRole userRole);
        Task DeleteAsync(int userId, int roleId);
    }
}
