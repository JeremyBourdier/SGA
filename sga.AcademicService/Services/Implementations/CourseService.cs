using sga.AcademicService.Services.Interfaces;
using sga.AcademicService.Repositories.Interfaces;
using sga.AcademicService.DTOs;
using sga.Data.Entities;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseDTO>> GetAllCoursesAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CourseDTO>>(courses);
        }

        public async Task<CourseDTO?> GetCourseByIdAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            return course == null ? null : _mapper.Map<CourseDTO>(course);
        }

        public async Task<bool> AddCourseAsync(CourseDTO courseDto)
        {
            if (courseDto == null)
                return false; // Evita agregar nulos.

            var course = _mapper.Map<Course>(courseDto);
            await _courseRepository.AddAsync(course);
            return true;
        }

        public async Task<bool> UpdateCourseAsync(int id, CourseDTO courseDto)
        {
            if (courseDto == null)
                return false; // Evita NullReferenceException.

            var existingCourse = await _courseRepository.GetByIdAsync(id);
            if (existingCourse == null)
                return false; // Retorna falso si el curso no existe.

            _mapper.Map(courseDto, existingCourse);
            await _courseRepository.UpdateAsync(existingCourse);
            return true;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var existingCourse = await _courseRepository.GetByIdAsync(id);
            if (existingCourse == null)
                return false; // No intenta eliminar si el curso no existe.

            await _courseRepository.DeleteAsync(id);
            return true;
        }
    }
}
