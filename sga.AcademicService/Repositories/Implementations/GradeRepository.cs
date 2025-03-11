using Microsoft.EntityFrameworkCore;
using sga.AcademicService.Repositories.Interfaces;
using sga.Data;
using sga.Data.Entities.AcademicService;

namespace sga.AcademicService.Repositories.Implementations;

public class GradeRepository : IGradeRepository
{
    private readonly AcademicDbContext _context;

    public GradeRepository(AcademicDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Grade>> GetAllAsync()
        => await _context.Grades.AsNoTracking().ToListAsync();

    public async Task<Grade?> GetByIdAsync(int id)
        => await _context.Grades.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id);

    public async Task<bool> AddAsync(Grade grade)
    {
        await _context.Grades.AddAsync(grade);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(Grade grade)
    {
        var existing = await _context.Grades.FindAsync(grade.Id);
        if (existing == null) return false;

        _context.Entry(existing).CurrentValues.SetValues(grade);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var grade = await _context.Grades.FindAsync(id);
        if (grade == null) return false;

        _context.Grades.Remove(grade);
        await _context.SaveChangesAsync();
        return true;
    }
}
