using AutoMapper;
using Moq;
using sga.AcademicService.DTOs;
using sga.AcademicService.Repositories.Interfaces;
using sga.AcademicService.Services.Implementations;
using sga.Data.Entities.AcademicService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace sga.AcademicService.Tests;

public class AttendanceServiceTests
{
    private readonly AttendanceService _service;
    private readonly Mock<IAttendanceRepository> _repoMock;
    private readonly IMapper _mapper;

    public AttendanceServiceTests()
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Attendance, AttendanceDTO>().ReverseMap();
        });

        _mapper = mapperConfig.CreateMapper();
        _repoMock = new Mock<IAttendanceRepository>();
        _service = new AttendanceService(_repoMock.Object, _mapper);
    }

    [Fact]
    public async Task GetAllAttendances_ShouldReturnList()
    {
        _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Attendance> { new Attendance { Id = 1 } });
        var attendances = await _service.GetAllAttendancesAsync();
        Assert.Single(attendances);
    }

    [Fact]
    public async Task GetAttendanceById_ShouldReturnAttendance_WhenExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Attendance { Id = 1 });
        var attendance = await _service.GetAttendanceByIdAsync(1);
        Assert.NotNull(attendance);
        Assert.Equal(1, attendance.Id);
    }

    [Fact]
    public async Task GetAttendanceById_ShouldReturnNull_WhenNotExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Attendance?)null);
        var attendance = await _service.GetAttendanceByIdAsync(99);
        Assert.Null(attendance);
    }

    [Fact]
    public async Task CreateAttendance_ShouldReturnTrue()
    {
        var dto = new AttendanceDTO { AttendanceDate = DateTime.Now, Status = "Present", EnrollmentId = 1 };
        _repoMock.Setup(r => r.AddAsync(It.IsAny<Attendance>())).ReturnsAsync(true);
        Assert.True(await _service.AddAttendanceAsync(dto));
    }

    [Fact]
    public async Task UpdateAttendance_ShouldReturnTrue_WhenExists()
    {
        var dto = new AttendanceDTO { AttendanceDate = DateTime.Now, Status = "Absent", EnrollmentId = 1 };
        _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Attendance { Id = 1 });
        _repoMock.Setup(r => r.UpdateAsync(It.IsAny<Attendance>())).ReturnsAsync(true);

        var result = await _service.UpdateAttendanceAsync(1, dto);
        Assert.True(result);
    }

    [Fact]
    public async Task UpdateAttendance_ShouldReturnFalse_WhenNotExists()
    {
        var dto = new AttendanceDTO { AttendanceDate = DateTime.Now, Status = "Absent", EnrollmentId = 1 };
        _repoMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Attendance?)null);

        var result = await _service.UpdateAttendanceAsync(99, dto);
        Assert.False(result);
    }

    [Fact]
    public async Task DeleteAttendance_ShouldReturnTrue_WhenExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Attendance { Id = 1 });
        _repoMock.Setup(r => r.DeleteAsync(1)).ReturnsAsync(true);

        var result = await _service.DeleteAttendanceAsync(1);
        Assert.True(result);
    }

    [Fact]
    public async Task DeleteAttendance_ShouldReturnFalse_WhenNotExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Attendance?)null);

        var result = await _service.DeleteAttendanceAsync(99);
        Assert.False(result);
    }
}
