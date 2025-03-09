using Microsoft.AspNetCore.Mvc;
using sga.AcademicService.DTOs;
using sga.AcademicService.Services.Interfaces;
using System.Threading.Tasks;

namespace sga.AcademicService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttendanceController : ControllerBase
{
    private readonly IAttendanceService _attendanceService;

    public AttendanceController(IAttendanceService attendanceService)
    {
        _attendanceService = attendanceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAttendances()
        => Ok(await _attendanceService.GetAllAttendancesAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAttendance(int id)
    {
        var attendance = await _attendanceService.GetAttendanceByIdAsync(id);
        return attendance == null ? NotFound() : Ok(attendance);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAttendance([FromBody] AttendanceDTO dto)
    {
        var result = await _attendanceService.AddAttendanceAsync(dto);
        return result ? CreatedAtAction(nameof(GetAttendance), new { id = dto.Id }, dto) : BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAttendance(int id, [FromBody] AttendanceDTO dto)
    {
        var result = await _attendanceService.UpdateAttendanceAsync(id, dto);
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAttendance(int id)
    {
        var result = await _attendanceService.DeleteAttendanceAsync(id);
        return result ? NoContent() : NotFound();
    }
}
