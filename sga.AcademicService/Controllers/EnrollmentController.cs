using Microsoft.AspNetCore.Mvc;
using sga.AcademicService.DTOs;
using sga.AcademicService.Services.Interfaces;
using System.Threading.Tasks;

namespace sga.AcademicService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EnrollmentController : ControllerBase
{
    private readonly IEnrollmentService _service;

    public EnrollmentController(IEnrollmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetEnrollments()
        => Ok(await _service.GetAllEnrollmentsAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEnrollment(int id)
    {
        var enrollment = await _service.GetEnrollmentByIdAsync(id);
        return enrollment == null ? NotFound() : Ok(enrollment);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEnrollment([FromBody] EnrollmentDTO dto)
    {
        var result = await _service.AddEnrollmentAsync(dto);
        return result ? CreatedAtAction(nameof(GetEnrollment), new { id = dto.Id }, dto) : BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEnrollment(int id, [FromBody] EnrollmentDTO dto)
    {
        var result = await _service.UpdateEnrollmentAsync(id, dto);
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEnrollment(int id)
    {
        var result = await _service.DeleteEnrollmentAsync(id);
        return result ? NoContent() : NotFound();
    }
}
