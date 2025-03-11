using sga.AcademicService.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Services.Interfaces;

public interface IDegreeService
{
    Task<IEnumerable<DegreeDTO>> GetAllDegreesAsync();
    Task<DegreeDTO?> GetDegreeByIdAsync(int id);
    Task<bool> AddDegreeAsync(DegreeDTO dto);
    Task<bool> UpdateDegreeAsync(int id, DegreeDTO dto);
    Task<bool> DeleteDegreeAsync(int id);
}
