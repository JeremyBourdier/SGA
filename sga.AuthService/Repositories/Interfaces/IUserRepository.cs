using sga.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AuthService.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<bool> AddAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
    }
}
