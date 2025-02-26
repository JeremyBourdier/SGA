using sga.AcademicService.Services.Interfaces;
using sga.Data.Entities;
using sga.AcademicService.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        public async Task<Course?> GetCourseByIdAsync(int id)
        {
            return await _courseRepository.GetByIdAsync(id);
        }

        public async Task<bool> AddCourseAsync(Course course)
        {
            if (course == null)
                return false; // Manejo de error en caso de curso nulo.

            await _courseRepository.AddAsync(course);
            return true;
        }

        public async Task<bool> UpdateCourseAsync(Course course)
        {
            if (course == null)
                return false; // Evita NullReferenceException.

            var existingCourse = await _courseRepository.GetByIdAsync(course.Id);
            if (existingCourse == null)
                return false; // Retorna falso si el curso no existe.

            await _courseRepository.UpdateAsync(course);
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
