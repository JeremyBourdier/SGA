using Microsoft.EntityFrameworkCore;
using sga.AcademicService.Repositories.Interfaces;
using sga.Data;
using sga.Data.Entities.AcademicService;

namespace sga.AcademicService.Repositories.Implementations;

public class EnrollmentRepository : IEnrollmentRepository
{
    private readonly AcademicDbContext _context;

    public EnrollmentRepository(AcademicDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Enrollment>> GetAllAsync()
        => await _context.Enrollments.AsNoTracking().ToListAsync();

    public async Task<Enrollment?> GetByIdAsync(int id)
        => await _context.Enrollments.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

    public async Task<bool> AddAsync(Enrollment enrollment)
    {
        await _context.Enrollments.AddAsync(enrollment);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(Enrollment enrollment)
    {
        var existing = await _context.Enrollments.FindAsync(enrollment.Id);
        if (existing == null) return false;

        _context.Entry(existing).CurrentValues.SetValues(enrollment);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var enrollment = await _context.Enrollments.FindAsync(id);
        if (enrollment == null) return false;

        _context.Enrollments.Remove(enrollment);
        await _context.SaveChangesAsync();
        return true;
    }
}
