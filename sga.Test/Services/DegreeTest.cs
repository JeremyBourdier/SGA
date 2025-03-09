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

public class DegreeServiceTests
{
    private readonly DegreeService _service;
    private readonly Mock<IDegreeRepository> _repoMock;
    private readonly IMapper _mapper;

    public DegreeServiceTests()
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Degree, DegreeDTO>().ReverseMap();
        });

        _mapper = mapperConfig.CreateMapper();
        _repoMock = new Mock<IDegreeRepository>();
        _service = new DegreeService(_repoMock.Object, _mapper);
    }

    [Fact]
    public async Task GetAllDegrees_ShouldReturnList()
    {
        _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Degree> { new Degree { Id = 1 } });
        var degrees = await _service.GetAllDegreesAsync();
        Assert.Single(degrees);
    }

    [Fact]
    public async Task GetDegreeById_ShouldReturnDegree_WhenExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Degree { Id = 1 });
        var degree = await _service.GetDegreeByIdAsync(1);
        Assert.NotNull(degree);
        Assert.Equal(1, degree.Id);
    }

    [Fact]
    public async Task GetDegreeById_ShouldReturnNull_WhenNotExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Degree?)null);
        var degree = await _service.GetDegreeByIdAsync(99);
        Assert.Null(degree);
    }

    [Fact]
    public async Task CreateDegree_ShouldReturnTrue()
    {
        var dto = new DegreeDTO { Name = "Software Development", Duration = 7, Modality = "onsite" };
        _repoMock.Setup(r => r.AddAsync(It.IsAny<Degree>())).ReturnsAsync(true);
        Assert.True(await _service.AddDegreeAsync(dto));
    }

    [Fact]
    public async Task UpdateDegree_ShouldReturnTrue_WhenExists()
    {
        var dto = new DegreeDTO { Name = "Systems Engineering", Duration = 8, Modality = "semi-onsite" };
        _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Degree { Id = 1 });
        _repoMock.Setup(r => r.UpdateAsync(It.IsAny<Degree>())).ReturnsAsync(true);

        var result = await _service.UpdateDegreeAsync(1, dto);
        Assert.True(result);
    }

    [Fact]
    public async Task UpdateDegree_ShouldReturnFalse_WhenNotExists()
    {
        var dto = new DegreeDTO { Name = "Systems Engineering", Duration = 8, Modality = "semi-onsite" };
        _repoMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Degree?)null);

        var result = await _service.UpdateDegreeAsync(99, dto);
        Assert.False(result);
    }

    [Fact]
    public async Task DeleteDegree_ShouldReturnTrue_WhenExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Degree { Id = 1 });
        _repoMock.Setup(r => r.DeleteAsync(1)).ReturnsAsync(true);

        var result = await _service.DeleteDegreeAsync(1);
        Assert.True(result);
    }

    [Fact]
    public async Task DeleteDegree_ShouldReturnFalse_WhenNotExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Degree?)null);

        var result = await _service.DeleteDegreeAsync(99);
        Assert.False(result);
    }
}