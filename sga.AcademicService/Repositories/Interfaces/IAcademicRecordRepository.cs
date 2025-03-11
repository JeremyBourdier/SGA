using sga.Data.Entities.AcademicService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Repositories.Interfaces;

public interface IAcademicRecordRepository
{
    Task<IEnumerable<AcademicRecord>> GetAllAsync();
    Task<AcademicRecord?> GetByIdAsync(int id);
    Task<bool> AddAsync(AcademicRecord record);
    Task<bool> UpdateAsync(AcademicRecord record);
    Task<bool> DeleteAsync(int id);
}
