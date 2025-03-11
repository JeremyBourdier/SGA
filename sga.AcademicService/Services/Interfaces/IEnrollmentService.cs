using sga.AcademicService.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Services.Interfaces;

public interface IEnrollmentService
{
    Task<IEnumerable<EnrollmentDTO>> GetAllEnrollmentsAsync();
    Task<EnrollmentDTO?> GetEnrollmentByIdAsync(int id);
    Task<bool> AddEnrollmentAsync(EnrollmentDTO dto);
    Task<bool> UpdateEnrollmentAsync(int id, EnrollmentDTO dto);
    Task<bool> DeleteEnrollmentAsync(int id);
}
