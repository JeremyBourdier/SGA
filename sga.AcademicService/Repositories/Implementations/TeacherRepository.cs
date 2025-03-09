using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sga.Data;
using sga.Data.Entities.AcademicService;
using sga.AcademicService.Repositories.Interfaces;

namespace sga.AcademicService.Repositories.Implementations
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AcademicDbContext _context;

        public TeacherRepository(AcademicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _context.Teachers.AsNoTracking().ToListAsync();
        }

        public async Task<Teacher?> GetByIdAsync(int id)
        {
            return await _context.Teachers.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<bool> AddAsync(Teacher teacher)
        {
            try
            {
                await _context.Teachers.AddAsync(teacher);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error AddAsync Teacher: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Teacher teacher)
        {
            try
            {
                var existing = await _context.Teachers.FindAsync(teacher.Id);
                if (existing == null) return false;

                _context.Entry(existing).CurrentValues.SetValues(teacher);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error UpdateAsync Teacher: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var teacher = await _context.Teachers.FindAsync(id);
                if (teacher == null) return false;

                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error DeleteAsync Teacher: {ex.Message}");
                return false;
            }
        }
    }
}
