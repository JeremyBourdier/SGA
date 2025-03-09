using sga.Data.Entities.AcademicService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Repositories.Interfaces;

public interface IEnrollmentRepository
{
    Task<IEnumerable<Enrollment>> GetAllAsync();
    Task<Enrollment?> GetByIdAsync(int id);
    Task<bool> AddAsync(Enrollment enrollment);
    Task<bool> UpdateAsync(Enrollment enrollment);
    Task<bool> DeleteAsync(int id);
}
