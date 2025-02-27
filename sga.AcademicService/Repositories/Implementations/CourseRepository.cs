using sga.Data;
using sga.Data.Entities;
using sga.AcademicService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Repositories.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AcademicDbContext _context;

        public CourseRepository(AcademicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses
                .AsNoTracking()  // Mejora el rendimiento en consultas de solo lectura
                .ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id); // Más seguro que FindAsync
        }

        public async Task<bool> AddAsync(Course course)
        {
            try
            {
                await _context.Courses.AddAsync(course);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Loguear el error antes de lanzar la excepción
                Console.WriteLine($"Error en AddAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Course course)
        {
            try
            {
                var existingCourse = await _context.Courses.FindAsync(course.Id);
                if (existingCourse == null)
                {
                    return false; // Indica que no se encontró el curso
                }

                _context.Entry(existingCourse).CurrentValues.SetValues(course);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en UpdateAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var course = await _context.Courses.FindAsync(id);
                if (course == null)
                {
                    return false; // Indica que el curso no existe
                }

                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en DeleteAsync: {ex.Message}");
                return false;
            }
        }
    }
}
