using sga.Data.Entities.AcademicService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Repositories.Interfaces
{
    public interface IGradeRepository
    {
        Task<IEnumerable<Grade>> GetAllAsync();
        Task<Grade?> GetByIdAsync(int id);
        Task<bool> AddAsync(Grade grade);
        Task<bool> UpdateAsync(Grade grade);
        Task<bool> DeleteAsync(int id);
    }
}
