using AutoMapper;
using Moq;
using sga.AcademicService.DTOs;
using sga.AcademicService.Repositories.Interfaces;
using sga.AcademicService.Services.Implementations;
using sga.Data.Entities.AcademicService;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace sga.AcademicService.Tests;

public class AcademicRecordServiceTests
{
    private readonly AcademicRecordService _service;
    private readonly Mock<IAcademicRecordRepository> _repoMock;
    private readonly IMapper _mapper;

    public AcademicRecordServiceTests()
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<AcademicRecord, AcademicRecordDTO>().ReverseMap();
        });

        _mapper = mapperConfig.CreateMapper();
        _repoMock = new Mock<IAcademicRecordRepository>();
        _service = new AcademicRecordService(_repoMock.Object, _mapper);
    }

    [Fact]
    public async Task GetAllRecords_ShouldReturnList()
    {
        _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<AcademicRecord> { new AcademicRecord { Id = 1 } });
        var records = await _service.GetAllRecordsAsync();
        Assert.Single(records);
    }

    [Fact]
    public async Task GetRecordById_ShouldReturnRecord_WhenExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new AcademicRecord { Id = 1 });
        var record = await _service.GetRecordByIdAsync(1);
        Assert.NotNull(record);
        Assert.Equal(1, record.Id);
    }

    [Fact]
    public async Task GetRecordById_ShouldReturnNull_WhenNotExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((AcademicRecord?)null);
        var record = await _service.GetRecordByIdAsync(99);
        Assert.Null(record);
    }

    [Fact]
    public async Task AddRecord_ShouldReturnTrue()
    {
        var dto = new AcademicRecordDTO { Average = 90, Term = "2023-1", StudentId = 1 };
        _repoMock.Setup(r => r.AddAsync(It.IsAny<AcademicRecord>())).ReturnsAsync(true);
        Assert.True(await _service.AddRecordAsync(dto));
    }

    [Fact]
    public async Task UpdateRecord_ShouldReturnTrue_WhenExists()
    {
        var dto = new AcademicRecordDTO { Average = 85, Term = "2023-1", StudentId = 1 };
        _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new AcademicRecord { Id = 1 });
        _repoMock.Setup(r => r.UpdateAsync(It.IsAny<AcademicRecord>())).ReturnsAsync(true);

        var result = await _service.UpdateRecordAsync(1, dto);
        Assert.True(result);
    }

    [Fact]
    public async Task UpdateRecord_ShouldReturnFalse_WhenNotExists()
    {
        var dto = new AcademicRecordDTO { Average = 85, Term = "2023-1", StudentId = 1 };
        _repoMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((AcademicRecord?)null);

        var result = await _service.UpdateRecordAsync(99, dto);
        Assert.False(result);
    }

    [Fact]
    public async Task DeleteRecord_ShouldReturnTrue_WhenExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new AcademicRecord { Id = 1 });
        _repoMock.Setup(r => r.DeleteAsync(1)).ReturnsAsync(true);

        var result = await _service.DeleteRecordAsync(1);
        Assert.True(result);
    }

    [Fact]
    public async Task DeleteRecord_ShouldReturnFalse_WhenNotExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((AcademicRecord?)null);

        var result = await _service.DeleteRecordAsync(99);
        Assert.False(result);
    }
}