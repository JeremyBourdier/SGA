using sga.AcademicService.Repositories.Interfaces;
using sga.Data.Entities.AcademicService;
using sga.Data;
using Microsoft.EntityFrameworkCore;


namespace sga.AcademicService.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AcademicDbContext _context;

        public StudentRepository(AcademicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
            => await _context.Students.AsNoTracking().ToListAsync();

        public async Task<Student?> GetByIdAsync(int id)
            => await _context.Students.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);

        public async Task<bool> AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Student student)
        {
            var existing = await _context.Students.FindAsync(student.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return false;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
