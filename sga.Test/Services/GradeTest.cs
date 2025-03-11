using AutoMapper;
using Moq;
using sga.AcademicService.DTOs;
using sga.AcademicService.Repositories.Interfaces;
using sga.AcademicService.Services.Implementations;
using sga.Data.Entities.AcademicService;
using Xunit;

namespace sga.AcademicService.Tests;

public class GradeServiceTests
{
    private readonly GradeService _service;
    private readonly Mock<IGradeRepository> _repoMock;
    private readonly IMapper _mapper;

    public GradeServiceTests()
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Grade, GradeDTO>().ReverseMap();
        });

        _mapper = mapperConfig.CreateMapper();
        _repoMock = new Mock<IGradeRepository>();
        _service = new GradeService(_repoMock.Object, _mapper);
    }

    [Fact]
    public async Task GetAllGrades_ShouldReturnGradesList()
    {
        _repoMock.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(new List<Grade> { new Grade { Id = 1 } });

        var grades = await _service.GetAllGradesAsync();

        Assert.Single(grades);
    }

    [Fact]
    public async Task GetGradeById_ShouldReturnGrade_WhenExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Grade { Id = 1 });

        var result = await _service.GetGradeByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }

    [Fact]
    public async Task AddGrade_ShouldReturnTrue_WhenValid()
    {
        var dto = new GradeDTO { FinalScore = 95, EvaluationType = "Final", EnrollmentId = 1 };

        _repoMock.Setup(r => r.AddAsync(It.IsAny<Grade>())).ReturnsAsync(true);

        var result = await _service.AddGradeAsync(dto);

        Assert.True(result);
    }

    [Fact]
    public async Task UpdateGrade_ShouldReturnTrue_WhenExists()
    {
        var dto = new GradeDTO { FinalScore = 95, EvaluationType = "Final", EnrollmentId = 1 };

        _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Grade { Id = 1 });
        _repoMock.Setup(r => r.UpdateAsync(It.IsAny<Grade>())).ReturnsAsync(true);

        var result = await _service.UpdateGradeAsync(1, dto);

        Assert.True(result);
    }

    [Fact]
    public async Task DeleteGrade_ShouldReturnTrue_WhenExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Grade { Id = 1 });
        _repoMock.Setup(r => r.DeleteAsync(1)).ReturnsAsync(true);

        var result = await _service.DeleteGradeAsync(1);

        Assert.True(result);
    }

    [Fact]
    public async Task DeleteGrade_ShouldReturnFalse_WhenNotExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Grade?)null);

        var result = await _service.DeleteGradeAsync(99);

        Assert.False(result);
    }
}
