﻿using Microsoft.AspNetCore.Mvc;
using sga.AcademicService.Services.Interfaces;
using sga.AcademicService.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: api/course
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        // GET: api/course/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDTO>> GetCourse(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);

            if (course == null)
            {
                return NotFound(new { message = "Curso no encontrado." });
            }

            return Ok(course);
        }

        // POST: api/course
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseDTO courseDto)
        {
            if (courseDto == null)
            {
                return BadRequest(new { message = "El curso no puede ser nulo." });
            }

            var success = await _courseService.AddCourseAsync(courseDto);
            if (!success)
            {
                return BadRequest(new { message = "No se pudo agregar el curso." });
            }

            return CreatedAtAction(nameof(GetCourse), new { id = courseDto.Id }, courseDto);
        }

        // PUT: api/course/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseDTO courseDto)
        {
            if (courseDto == null)
            {
                return BadRequest(new { message = "Datos inválidos para actualizar el curso." });
            }

            var success = await _courseService.UpdateCourseAsync(id, courseDto);
            if (!success)
            {
                return NotFound(new { message = "Curso no encontrado." });
            }

            return NoContent();
        }

        // DELETE: api/course/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var success = await _courseService.DeleteCourseAsync(id);
            if (!success)
            {
                return NotFound(new { message = "Curso no encontrado." });
            }

            return NoContent();
        }
    }
}
