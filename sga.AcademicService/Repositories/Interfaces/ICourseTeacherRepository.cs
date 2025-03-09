using sga.Data.Entities.AcademicService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Repositories.Interfaces;

public interface ICourseTeacherRepository
{
    Task<IEnumerable<CourseTeacher>> GetAllAsync();
    Task<CourseTeacher?> GetByIdAsync(int id);
    Task<bool> AddAsync(CourseTeacher courseTeacher);
    Task<bool> UpdateAsync(CourseTeacher courseTeacher);
    Task<bool> DeleteAsync(int id);
}
