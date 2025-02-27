using sga.Data;
using sga.Data.Entities;
using sga.AuthService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AuthService.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext _context;

        public UserRepository(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> AddAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Loggear el error
                Console.WriteLine($"Error en AddAsync User: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(User user)
        {
            try
            {
                var existing = await _context.Users.FindAsync(user.Id);
                if (existing == null)
                {
                    return false;
                }

                _context.Entry(existing).CurrentValues.SetValues(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en UpdateAsync User: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return false;
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en DeleteAsync User: {ex.Message}");
                return false;
            }
        }
    }
}
