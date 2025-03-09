using AutoMapper;
using sga.AcademicService.DTOs;
using sga.AcademicService.Repositories.Interfaces;
using sga.AcademicService.Services.Interfaces;
using sga.Data.Entities.AcademicService;

namespace sga.AcademicService.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDTO>> GetAllStudentsAsync()
            => _mapper.Map<IEnumerable<StudentDTO>>(await _repo.GetAllAsync());

        public async Task<StudentDTO?> GetStudentByIdAsync(int id)
        {
            var student = await _repo.GetByIdAsync(id);
            return student == null ? null : _mapper.Map<StudentDTO>(student);
        }

        public async Task<bool> AddStudentAsync(StudentDTO dto)
        {
            var entity = _mapper.Map<Student>(dto);
            return await _repo.AddAsync(entity);
        }

        public async Task<bool> UpdateStudentAsync(int id, StudentDTO dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;

            _mapper.Map(dto, existing);
            return await _repo.UpdateAsync(existing);
        }

        public async Task<bool> DeleteStudentAsync(int id)
            => await _repo.DeleteAsync(id);
    }
}
