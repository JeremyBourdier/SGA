using AutoMapper;
using sga.AcademicService.DTOs;
using sga.AcademicService.Repositories.Interfaces;
using sga.AcademicService.Services.Interfaces;
using sga.Data.Entities.AcademicService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Services.Implementations;

public class DegreeService : IDegreeService
{
    private readonly IDegreeRepository _repository;
    private readonly IMapper _mapper;

    public DegreeService(IDegreeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DegreeDTO>> GetAllDegreesAsync()
        => _mapper.Map<IEnumerable<DegreeDTO>>(await _repository.GetAllAsync());

    public async Task<DegreeDTO?> GetDegreeByIdAsync(int id)
    {
        var degree = await _repository.GetByIdAsync(id);
        return degree == null ? null : _mapper.Map<DegreeDTO>(degree);
    }

    public async Task<bool> AddDegreeAsync(DegreeDTO dto)
    {
        var entity = _mapper.Map<Degree>(dto);
        return await _repository.AddAsync(entity);
    }

    public async Task<bool> UpdateDegreeAsync(int id, DegreeDTO dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return false;

        _mapper.Map(dto, existing);
        return await _repository.UpdateAsync(existing);
    }

    public async Task<bool> DeleteDegreeAsync(int id)
        => await _repository.DeleteAsync(id);
}
