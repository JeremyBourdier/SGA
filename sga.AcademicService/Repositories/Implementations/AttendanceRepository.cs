using Microsoft.EntityFrameworkCore;
using sga.AcademicService.Repositories.Interfaces;
using sga.Data;
using sga.Data.Entities.AcademicService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Repositories.Implementations;

public class AttendanceRepository : IAttendanceRepository
{
    private readonly AcademicDbContext _context;

    public AttendanceRepository(AcademicDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Attendance>> GetAllAsync()
        => await _context.Attendances.AsNoTracking().ToListAsync();

    public async Task<Attendance?> GetByIdAsync(int id)
        => await _context.Attendances.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);

    public async Task<bool> AddAsync(Attendance attendance)
    {
        await _context.Attendances.AddAsync(attendance);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(Attendance attendance)
    {
        var existing = await _context.Attendances.FindAsync(attendance.Id);
        if (existing == null) return false;

        _context.Entry(existing).CurrentValues.SetValues(attendance);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var attendance = await _context.Attendances.FindAsync(id);
        if (attendance == null) return false;

        _context.Attendances.Remove(attendance);
        await _context.SaveChangesAsync();
        return true;
    }
}
