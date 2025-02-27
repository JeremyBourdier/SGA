using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sga.Data;
using sga.Data.Entities;
using sga.AuthService.Repositories.Interfaces;

namespace sga.AuthService.Repositories.Implementations
{
    public class RolePermissionRepository : IRolePermissionRepository
    {
        private readonly AuthDbContext _context;

        public RolePermissionRepository(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RolePermission>> GetAllAsync()
        {
            return await _context.RolePermissions.AsNoTracking().ToListAsync();
        }

        public async Task<RolePermission?> GetByIdsAsync(int roleId, int permissionId)
        {
            return await _context.RolePermissions
                .AsNoTracking()
                .FirstOrDefaultAsync(rp => rp.RoleID == roleId && rp.PermissionID == permissionId);
        }

        public async Task<bool> AddAsync(RolePermission entity)
        {
            try
            {
                await _context.RolePermissions.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error AddAsync RolePermission: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int roleId, int permissionId)
        {
            try
            {
                var existing = await _context.RolePermissions.FindAsync(roleId, permissionId);
                if (existing == null) return false;

                _context.RolePermissions.Remove(existing);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error DeleteAsync RolePermission: {ex.Message}");
                return false;
            }
        }
    }
}
