using Microsoft.EntityFrameworkCore;
using sga.AcademicService.Repositories.Interfaces;
using sga.Data;
using sga.Data.Entities.AcademicService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Repositories.Implementations;

public class DegreeRepository : IDegreeRepository
{
    private readonly AcademicDbContext _context;

    public DegreeRepository(AcademicDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Degree>> GetAllAsync()
        => await _context.Degrees.AsNoTracking().ToListAsync();

    public async Task<Degree?> GetByIdAsync(int id)
        => await _context.Degrees.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id);

    public async Task<bool> AddAsync(Degree degree)
    {
        await _context.Degrees.AddAsync(degree);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(Degree degree)
    {
        var existingDegree = await _context.Degrees.FindAsync(degree.Id);
        if (existingDegree == null) return false;

        _context.Entry(existingDegree).CurrentValues.SetValues(degree);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var degree = await _context.Degrees.FindAsync(id);
        if (degree == null) return false;

        _context.Degrees.Remove(degree);
        await _context.SaveChangesAsync();
        return true;
    }
}
