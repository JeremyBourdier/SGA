using Microsoft.EntityFrameworkCore;
using sga.AcademicService.Repositories.Interfaces;
using sga.Data;
using sga.Data.Entities.AcademicService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Repositories.Implementations;

public class AcademicRecordRepository : IAcademicRecordRepository
{
    private readonly AcademicDbContext _context;

    public AcademicRecordRepository(AcademicDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AcademicRecord>> GetAllAsync()
        => await _context.AcademicRecords.AsNoTracking().ToListAsync();

    public async Task<AcademicRecord?> GetByIdAsync(int id)
        => await _context.AcademicRecords.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);

    public async Task<bool> AddAsync(AcademicRecord record)
    {
        await _context.AcademicRecords.AddAsync(record);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(AcademicRecord record)
    {
        var existing = await _context.AcademicRecords.FindAsync(record.Id);
        if (existing == null) return false;

        _context.Entry(existing).CurrentValues.SetValues(record);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var record = await _context.AcademicRecords.FindAsync(id);
        if (record == null) return false;

        _context.AcademicRecords.Remove(record);
        await _context.SaveChangesAsync();
        return true;
    }
}
