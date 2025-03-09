using sga.AcademicService.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Services.Interfaces;

public interface IAttendanceService
{
    Task<IEnumerable<AttendanceDTO>> GetAllAttendancesAsync();
    Task<AttendanceDTO?> GetAttendanceByIdAsync(int id);
    Task<bool> AddAttendanceAsync(AttendanceDTO dto);
    Task<bool> UpdateAttendanceAsync(int id, AttendanceDTO dto);
    Task<bool> DeleteAttendanceAsync(int id);
}
