using AutoMapper;
using sga.AcademicService.DTOs;
using sga.AcademicService.Repositories.Interfaces;
using sga.AcademicService.Services.Interfaces;
using sga.Data.Entities.AcademicService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Services.Implementations;

public class AcademicRecordService : IAcademicRecordService
{
    private readonly IAcademicRecordRepository _repository;
    private readonly IMapper _mapper;

    public AcademicRecordService(IAcademicRecordRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AcademicRecordDTO>> GetAllRecordsAsync()
        => _mapper.Map<IEnumerable<AcademicRecordDTO>>(await _repository.GetAllAsync());

    public async Task<AcademicRecordDTO?> GetRecordByIdAsync(int id)
    {
        var record = await _repository.GetByIdAsync(id);
        return record == null ? null : _mapper.Map<AcademicRecordDTO>(record);
    }

    public async Task<bool> AddRecordAsync(AcademicRecordDTO dto)
    {
        var entity = _mapper.Map<AcademicRecord>(dto);
        return await _repository.AddAsync(entity);
    }

    public async Task<bool> UpdateRecordAsync(int id, AcademicRecordDTO dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return false;

        _mapper.Map(dto, existing);
        return await _repository.UpdateAsync(existing);
    }

    public async Task<bool> DeleteRecordAsync(int id)
        => await _repository.DeleteAsync(id);
}
