using sga.AcademicService.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherDTO>> GetAllTeachersAsync();
        Task<TeacherDTO?> GetTeacherByIdAsync(int id);
        Task<bool> AddTeacherAsync(TeacherDTO dto);
        Task<bool> UpdateTeacherAsync(int id, TeacherDTO dto);
        Task<bool> DeleteTeacherAsync(int id);
    }
}
