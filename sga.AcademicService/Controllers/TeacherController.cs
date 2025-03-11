using Microsoft.AspNetCore.Mvc;
using sga.AcademicService.DTOs;
using sga.AcademicService.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        // GET: api/teacher
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherDTO>>> GetAllTeachers()
        {
            var teachers = await _teacherService.GetAllTeachersAsync();
            return Ok(teachers);
        }

        // GET: api/teacher/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherDTO>> GetTeacher(int id)
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(id);
            if (teacher == null)
                return NotFound(new { message = "Teacher no encontrado." });

            return Ok(teacher);
        }

        // POST: api/teacher
        [HttpPost]
        public async Task<IActionResult> AddTeacher([FromBody] TeacherDTO dto)
        {
            if (dto == null)
                return BadRequest(new { message = "Datos del Teacher no válidos." });

            var success = await _teacherService.AddTeacherAsync(dto);
            if (!success)
                return BadRequest(new { message = "No se pudo crear el Teacher." });

            return Ok(dto);
        }

        // PUT: api/teacher/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, [FromBody] TeacherDTO dto)
        {
            if (dto == null)
                return BadRequest(new { message = "Datos del Teacher no válidos." });

            var success = await _teacherService.UpdateTeacherAsync(id, dto);
            if (!success)
                return NotFound(new { message = "Teacher no encontrado." });

            return NoContent();
        }

        // DELETE: api/teacher/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var success = await _teacherService.DeleteTeacherAsync(id);
            if (!success)
                return NotFound(new { message = "Teacher no encontrado." });

            return NoContent();
        }
    }
}
