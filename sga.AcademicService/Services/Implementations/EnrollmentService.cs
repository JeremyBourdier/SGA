using AutoMapper;
using sga.AcademicService.DTOs;
using sga.AcademicService.Repositories.Interfaces;
using sga.AcademicService.Services.Interfaces;
using sga.Data.Entities.AcademicService;

namespace sga.AcademicService.Services.Implementations;

public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository _repository;
    private readonly IMapper _mapper;

    public EnrollmentService(IEnrollmentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EnrollmentDTO>> GetAllEnrollmentsAsync()
        => _mapper.Map<IEnumerable<EnrollmentDTO>>(await _repository.GetAllAsync());

    public async Task<EnrollmentDTO?> GetEnrollmentByIdAsync(int id)
    {
        var enrollment = await _repository.GetByIdAsync(id);
        return enrollment == null ? null : _mapper.Map<EnrollmentDTO>(enrollment);
    }

    public async Task<bool> AddEnrollmentAsync(EnrollmentDTO dto)
    {
        var entity = _mapper.Map<Enrollment>(dto);
        return await _repository.AddAsync(entity);
    }

    public async Task<bool> UpdateEnrollmentAsync(int id, EnrollmentDTO dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return false;

        _mapper.Map(dto, existing);
        return await _repository.UpdateAsync(existing);
    }

    public async Task<bool> DeleteEnrollmentAsync(int id)
        => await _repository.DeleteAsync(id);
}
