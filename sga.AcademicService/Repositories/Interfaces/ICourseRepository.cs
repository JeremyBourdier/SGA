using sga.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);  // Puede devolver null si no encuentra el curso
        Task<bool> AddAsync(Course course);  // Devuelve true si la inserción es exitosa
        Task<bool> UpdateAsync(Course course);  // Devuelve true si la actualización es exitosa
        Task<bool> DeleteAsync(int id);  // Devuelve true si la eliminación es exitosa
    }
}
