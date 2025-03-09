using sga.AcademicService.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Services.Interfaces;

public interface IAcademicRecordService
{
    Task<IEnumerable<AcademicRecordDTO>> GetAllRecordsAsync();
    Task<AcademicRecordDTO?> GetRecordByIdAsync(int id);
    Task<bool> AddRecordAsync(AcademicRecordDTO dto);
    Task<bool> UpdateRecordAsync(int id, AcademicRecordDTO dto);
    Task<bool> DeleteRecordAsync(int id);
}
