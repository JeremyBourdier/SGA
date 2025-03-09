using Microsoft.AspNetCore.Mvc;
using sga.AcademicService.DTOs;
using sga.AcademicService.Services.Interfaces;
using System.Threading.Tasks;

namespace sga.AcademicService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DegreeController : ControllerBase
{
    private readonly IDegreeService _degreeService;

    public DegreeController(IDegreeService degreeService)
    {
        _degreeService = degreeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetDegrees()
        => Ok(await _degreeService.GetAllDegreesAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDegree(int id)
    {
        var degree = await _degreeService.GetDegreeByIdAsync(id);
        return degree == null ? NotFound() : Ok(degree);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDegree([FromBody] DegreeDTO dto)
    {
        var result = await _degreeService.AddDegreeAsync(dto);
        return result ? CreatedAtAction(nameof(GetDegree), new { id = dto.Id }, dto) : BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDegree(int id, [FromBody] DegreeDTO dto)
    {
        var result = await _degreeService.UpdateDegreeAsync(id, dto);
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDegree(int id)
    {
        var result = await _degreeService.DeleteDegreeAsync(id);
        return result ? NoContent() : NotFound();
    }
}
