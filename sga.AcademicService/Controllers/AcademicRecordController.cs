using Microsoft.AspNetCore.Mvc;
using sga.AcademicService.DTOs;
using sga.AcademicService.Services.Interfaces;
using System.Threading.Tasks;

namespace sga.AcademicService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AcademicRecordController : ControllerBase
{
    private readonly IAcademicRecordService _service;

    public AcademicRecordController(IAcademicRecordService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetRecords()
        => Ok(await _service.GetAllRecordsAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRecord(int id)
    {
        var record = await _service.GetRecordByIdAsync(id);
        return record == null ? NotFound() : Ok(record);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRecord([FromBody] AcademicRecordDTO dto)
    {
        var result = await _service.AddRecordAsync(dto);
        return result ? CreatedAtAction(nameof(GetRecord), new { id = dto.Id }, dto) : BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRecord(int id, [FromBody] AcademicRecordDTO dto)
    {
        var result = await _service.UpdateRecordAsync(id, dto);
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecord(int id)
    {
        var result = await _service.DeleteRecordAsync(id);
        return result ? NoContent() : NotFound();
    }
}
