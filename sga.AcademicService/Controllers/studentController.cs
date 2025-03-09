using Microsoft.AspNetCore.Mvc;
using sga.AcademicService.DTOs;
using sga.AcademicService.Services.Interfaces;

namespace sga.AcademicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> GetStudent(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            return student is null ? NotFound() : Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentDTO studentDto)
        {
            if (studentDto is null) return BadRequest();

            var result = await _studentService.AddStudentAsync(studentDto);
            return result ? CreatedAtAction(nameof(GetStudent), new { id = studentDto.Id }, studentDto) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentDTO studentDto)
        {
            var result = await _studentService.UpdateStudentAsync(id, studentDto);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentService.DeleteStudentAsync(id);
            return result ? NoContent() : NotFound();
        }
    }

}
