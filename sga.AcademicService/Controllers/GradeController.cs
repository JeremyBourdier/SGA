using Microsoft.AspNetCore.Mvc;
using sga.AcademicService.DTOs;
using sga.AcademicService.Services.Interfaces;

namespace sga.AcademicService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GradeController : ControllerBase
{
    private readonly IGradeService _gradeService;

    public GradeController(IGradeService gradeService)
    {
        _gradeService = gradeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetGrades()
        => Ok(await _gradeService.GetAllGradesAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGrade(int id)
    {
        var grade = await _gradeService.GetGradeByIdAsync(id);
        return grade == null ? NotFound() : Ok(grade);
    }

    [HttpPost]
    public async Task<IActionResult> CreateGrade([FromBody] GradeDTO dto)
    {
        var result = await _gradeService.AddGradeAsync(dto);
        return result ? CreatedAtAction(nameof(GetGrades), new { id = dto.Id }, dto) : BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGrade(int id, [FromBody] GradeDTO dto)
    {
        var result = await _gradeService.UpdateGradeAsync(id, dto);
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGrade(int id)
    {
        var result = await _gradeService.DeleteGradeAsync(id);
        return result ? NoContent() : NotFound();
    }
}
