using Microsoft.AspNetCore.Mvc;
using sga.AcademicService.DTOs;
using sga.AcademicService.Services.Interfaces;
using System.Threading.Tasks;

namespace sga.AcademicService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseTeacherController : ControllerBase
{
    private readonly ICourseTeacherService _service;

    public CourseTeacherController(ICourseTeacherService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetCourseTeachers()
        => Ok(await _service.GetAllCourseTeachersAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourseTeacher(int id)
    {
        var ct = await _service.GetCourseTeacherByIdAsync(id);
        return ct == null ? NotFound() : Ok(ct);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourseTeacher([FromBody] CourseTeacherDTO dto)
    {
        var result = await _service.AddCourseTeacherAsync(dto);
        return result ? CreatedAtAction(nameof(GetCourseTeacher), new { id = dto.Id }, dto) : BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourseTeacher(int id, [FromBody] CourseTeacherDTO dto)
    {
        var result = await _service.UpdateCourseTeacherAsync(id, dto);
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourseTeacher(int id)
    {
        var result = await _service.DeleteCourseTeacherAsync(id);
        return result ? NoContent() : NotFound();
    }
}
