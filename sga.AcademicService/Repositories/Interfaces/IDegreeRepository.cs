using sga.Data.Entities.AcademicService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Repositories.Interfaces;

public interface IDegreeRepository
{
    Task<IEnumerable<Degree>> GetAllAsync();
    Task<Degree?> GetByIdAsync(int id);
    Task<bool> AddAsync(Degree degree);
    Task<bool> UpdateAsync(Degree degree);
    Task<bool> DeleteAsync(int id);
}
