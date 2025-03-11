using sga.AcademicService.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Services.Interfaces;

public interface IGradeService
{
    Task<IEnumerable<GradeDTO>> GetAllGradesAsync();
    Task<GradeDTO?> GetGradeByIdAsync(int id);
    Task<bool> AddGradeAsync(GradeDTO dto);
    Task<bool> UpdateGradeAsync(int id, GradeDTO dto);
    Task<bool> DeleteGradeAsync(int id);
}
