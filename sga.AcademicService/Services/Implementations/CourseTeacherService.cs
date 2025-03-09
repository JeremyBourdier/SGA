using AutoMapper;
using sga.AcademicService.DTOs;
using sga.AcademicService.Repositories.Interfaces;
using sga.AcademicService.Services.Interfaces;
using sga.Data.Entities.AcademicService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Services.Implementations;

public class CourseTeacherService : ICourseTeacherService
{
    private readonly ICourseTeacherRepository _repository;
    private readonly IMapper _mapper;

    public CourseTeacherService(ICourseTeacherRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CourseTeacherDTO>> GetAllCourseTeachersAsync()
        => _mapper.Map<IEnumerable<CourseTeacherDTO>>(await _repository.GetAllAsync());

    public async Task<CourseTeacherDTO?> GetCourseTeacherByIdAsync(int id)
    {
        var ct = await _repository.GetByIdAsync(id);
        return ct == null ? null : _mapper.Map<CourseTeacherDTO>(ct);
    }

    public async Task<bool> AddCourseTeacherAsync(CourseTeacherDTO dto)
    {
        var entity = _mapper.Map<CourseTeacher>(dto);
        return await _repository.AddAsync(entity);
    }

    public async Task<bool> UpdateCourseTeacherAsync(int id, CourseTeacherDTO dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return false;

        _mapper.Map(dto, existing);
        return await _repository.UpdateAsync(existing);
    }

    public async Task<bool> DeleteCourseTeacherAsync(int id)
        => await _repository.DeleteAsync(id);
}
