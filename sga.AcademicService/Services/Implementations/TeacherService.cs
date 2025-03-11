using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using sga.AcademicService.DTOs;
using sga.AcademicService.Repositories.Interfaces;
using sga.AcademicService.Services.Interfaces;
using sga.Data.Entities.AcademicService;

namespace sga.AcademicService.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepo;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository teacherRepo, IMapper mapper)
        {
            _teacherRepo = teacherRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeacherDTO>> GetAllTeachersAsync()
        {
            var teachers = await _teacherRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<TeacherDTO>>(teachers);
        }

        public async Task<TeacherDTO?> GetTeacherByIdAsync(int id)
        {
            var teacher = await _teacherRepo.GetByIdAsync(id);
            return teacher == null ? null : _mapper.Map<TeacherDTO>(teacher);
        }

        public async Task<bool> AddTeacherAsync(TeacherDTO dto)
        {
            if (dto == null) return false;

            var entity = _mapper.Map<Teacher>(dto);
            return await _teacherRepo.AddAsync(entity);
        }

        public async Task<bool> UpdateTeacherAsync(int id, TeacherDTO dto)
        {
            if (dto == null) return false;

            var existing = await _teacherRepo.GetByIdAsync(id);
            if (existing == null) return false;

            // Mapea los nuevos valores al objeto existente
            _mapper.Map(dto, existing);
            return await _teacherRepo.UpdateAsync(existing);
        }

        public async Task<bool> DeleteTeacherAsync(int id)
        {
            var existing = await _teacherRepo.GetByIdAsync(id);
            if (existing == null) return false;

            return await _teacherRepo.DeleteAsync(id);
        }
    }
}
