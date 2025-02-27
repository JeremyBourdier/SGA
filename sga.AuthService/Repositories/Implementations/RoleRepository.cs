using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sga.Data;
using sga.Data.Entities;
using sga.AuthService.Repositories.Interfaces;

namespace sga.AuthService.Repositories.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AuthDbContext _context;

        public RoleRepository(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _context.Roles.AsNoTracking().ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            return await _context.Roles.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<bool> AddAsync(Role role)
        {
            try
            {
                await _context.Roles.AddAsync(role);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error AddAsync Role: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Role role)
        {
            try
            {
                var existing = await _context.Roles.FindAsync(role.Id);
                if (existing == null) return false;

                _context.Entry(existing).CurrentValues.SetValues(role);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error UpdateAsync Role: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var role = await _context.Roles.FindAsync(id);
                if (role == null) return false;

                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error DeleteAsync Role: {ex.Message}");
                return false;
            }
        }
    }
}
