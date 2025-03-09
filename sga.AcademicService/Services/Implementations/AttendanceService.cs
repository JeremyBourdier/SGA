using AutoMapper;
using sga.AcademicService.DTOs;
using sga.AcademicService.Repositories.Interfaces;
using sga.AcademicService.Services.Interfaces;
using sga.Data.Entities.AcademicService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AcademicService.Services.Implementations;

public class AttendanceService : IAttendanceService
{
    private readonly IAttendanceRepository _repository;
    private readonly IMapper _mapper;

    public AttendanceService(IAttendanceRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AttendanceDTO>> GetAllAttendancesAsync()
        => _mapper.Map<IEnumerable<AttendanceDTO>>(await _repository.GetAllAsync());

    public async Task<AttendanceDTO?> GetAttendanceByIdAsync(int id)
    {
        var attendance = await _repository.GetByIdAsync(id);
        return attendance == null ? null : _mapper.Map<AttendanceDTO>(attendance);
    }

    public async Task<bool> AddAttendanceAsync(AttendanceDTO dto)
    {
        var entity = _mapper.Map<Attendance>(dto);
        return await _repository.AddAsync(entity);
    }

    public async Task<bool> UpdateAttendanceAsync(int id, AttendanceDTO dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return false;

        _mapper.Map(dto, existing);
        return await _repository.UpdateAsync(existing);
    }

    public async Task<bool> DeleteAttendanceAsync(int id)
        => await _repository.DeleteAsync(id);
}
