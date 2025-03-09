using sga.Data.Entities.AcademicService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Repositories.Interfaces;

public interface IAttendanceRepository
{
    Task<IEnumerable<Attendance>> GetAllAsync();
    Task<Attendance?> GetByIdAsync(int id);
    Task<bool> AddAsync(Attendance attendance);
    Task<bool> UpdateAsync(Attendance attendance);
    Task<bool> DeleteAsync(int id);
}
