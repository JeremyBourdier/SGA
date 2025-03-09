using sga.AcademicService.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Services.Interfaces;

public interface ICourseTeacherService
{
    Task<IEnumerable<CourseTeacherDTO>> GetAllCourseTeachersAsync();
    Task<CourseTeacherDTO?> GetCourseTeacherByIdAsync(int id);
    Task<bool> AddCourseTeacherAsync(CourseTeacherDTO dto);
    Task<bool> UpdateCourseTeacherAsync(int id, CourseTeacherDTO dto);
    Task<bool> DeleteCourseTeacherAsync(int id);
}
