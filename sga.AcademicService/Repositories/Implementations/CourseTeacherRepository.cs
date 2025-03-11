using Microsoft.EntityFrameworkCore;
using sga.AcademicService.Repositories.Interfaces;
using sga.Data;
using sga.Data.Entities.AcademicService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Repositories.Implementations;

public class CourseTeacherRepository : ICourseTeacherRepository
{
    private readonly AcademicDbContext _context;

    public CourseTeacherRepository(AcademicDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CourseTeacher>> GetAllAsync()
        => await _context.CourseTeachers.AsNoTracking().ToListAsync();

    public async Task<CourseTeacher?> GetByIdAsync(int id)
        => await _context.CourseTeachers.AsNoTracking().FirstOrDefaultAsync(ct => ct.Id == id);

    public async Task<bool> AddAsync(CourseTeacher courseTeacher)
    {
        await _context.CourseTeachers.AddAsync(courseTeacher);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(CourseTeacher courseTeacher)
    {
        var existing = await _context.CourseTeachers.FindAsync(courseTeacher.Id);
        if (existing == null) return false;

        _context.Entry(existing).CurrentValues.SetValues(courseTeacher);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var courseTeacher = await _context.CourseTeachers.FindAsync(id);
        if (courseTeacher == null) return false;

        _context.CourseTeachers.Remove(courseTeacher);
        await _context.SaveChangesAsync();
        return true;
    }
}
