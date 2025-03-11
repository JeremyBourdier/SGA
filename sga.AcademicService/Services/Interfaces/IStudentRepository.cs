using sga.AcademicService.DTOs;

namespace sga.AcademicService.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetAllStudentsAsync();
        Task<StudentDTO?> GetStudentByIdAsync(int id);
        Task<bool> AddStudentAsync(StudentDTO dto);
        Task<bool> UpdateStudentAsync(int id, StudentDTO dto);
        Task<bool> DeleteStudentAsync(int id);
    }
}
