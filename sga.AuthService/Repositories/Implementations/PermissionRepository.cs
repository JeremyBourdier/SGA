using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sga.Data;
using sga.Data.Entities;
using sga.AuthService.Repositories.Interfaces;

namespace sga.AuthService.Repositories.Implementations
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly AuthDbContext _context;

        public PermissionRepository(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Permission>> GetAllAsync()
        {
            return await _context.Permissions.AsNoTracking().ToListAsync();
        }

        public async Task<Permission?> GetByIdAsync(int id)
        {
            return await _context.Permissions.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> AddAsync(Permission permission)
        {
            try
            {
                await _context.Permissions.AddAsync(permission);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error AddAsync Permission: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Permission permission)
        {
            try
            {
                var existing = await _context.Permissions.FindAsync(permission.Id);
                if (existing == null) return false;

                _context.Entry(existing).CurrentValues.SetValues(permission);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error UpdateAsync Permission: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var permission = await _context.Permissions.FindAsync(id);
                if (permission == null) return false;

                _context.Permissions.Remove(permission);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error DeleteAsync Permission: {ex.Message}");
                return false;
            }
        }
    }
}
