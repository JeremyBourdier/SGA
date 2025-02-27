using sga.AcademicService.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDTO>> GetAllCoursesAsync();
        Task<CourseDTO?> GetCourseByIdAsync(int id);
        Task<bool> AddCourseAsync(CourseDTO courseDto);
        Task<bool> UpdateCourseAsync(int id, CourseDTO courseDto);
        Task<bool> DeleteCourseAsync(int id);
    }
}
