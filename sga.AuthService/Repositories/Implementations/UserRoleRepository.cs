using Microsoft.EntityFrameworkCore;
using sga.AuthService.Repositories.Interfaces;
using sga.Data;
using sga.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AuthService.Repositories.Implementations
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly AuthDbContext _context;

        public UserRoleRepository(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            return await _context.UserRoles.ToListAsync();
        }

        public async Task<UserRole> GetByIdAsync(int userId, int roleId)
        {
            return await _context.UserRoles.FindAsync(userId, roleId);
        }

        public async Task AddAsync(UserRole userRole)
        {
            await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userId, int roleId)
        {
            var userRole = await GetByIdAsync(userId, roleId);
            if (userRole != null)
            {
                _context.UserRoles.Remove(userRole);
                await _context.SaveChangesAsync();
            }
        }
    }
}
