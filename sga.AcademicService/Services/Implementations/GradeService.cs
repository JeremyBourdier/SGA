using AutoMapper;
using sga.AcademicService.DTOs;
using sga.AcademicService.Repositories.Interfaces;
using sga.AcademicService.Services.Interfaces;
using sga.Data.Entities.AcademicService;

namespace sga.AcademicService.Services.Implementations;

public class GradeService : IGradeService
{
    private readonly IGradeRepository _repository;
    private readonly IMapper _mapper;

    public GradeService(IGradeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GradeDTO>> GetAllGradesAsync()
        => _mapper.Map<IEnumerable<GradeDTO>>(await _repository.GetAllAsync());

    public async Task<GradeDTO?> GetGradeByIdAsync(int id)
    {
        var grade = await _repository.GetByIdAsync(id);
        return grade == null ? null : _mapper.Map<GradeDTO>(grade);
    }

    public async Task<bool> AddGradeAsync(GradeDTO dto)
    {
        var entity = _mapper.Map<Grade>(dto);
        return await _repository.AddAsync(entity);
    }

    public async Task<bool> UpdateGradeAsync(int id, GradeDTO dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return false;

        _mapper.Map(dto, existing);
        return await _repository.UpdateAsync(existing);
    }



    public async Task<bool> DeleteGradeAsync(int id)
        => await _repository.DeleteAsync(id);
}
