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

public class EnrollmentServiceTests
{
    private readonly EnrollmentService _service;
    private readonly Mock<IEnrollmentRepository> _repoMock;
    private readonly IMapper _mapper;

    public EnrollmentServiceTests()
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Enrollment, EnrollmentDTO>().ReverseMap();
        });

        _mapper = mapperConfig.CreateMapper();
        _repoMock = new Mock<IEnrollmentRepository>();
        _service = new EnrollmentService(_repoMock.Object, _mapper);
    }

    [Fact]
    public async Task GetAllEnrollments_ShouldReturnList()
    {
        _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Enrollment> { new Enrollment { Id = 1 } });
        var enrollments = await _service.GetAllEnrollmentsAsync();
        Assert.Single(enrollments);
    }

    [Fact]
    public async Task GetEnrollmentById_ShouldReturnEnrollment_WhenExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Enrollment { Id = 1 });
        var enrollment = await _service.GetEnrollmentByIdAsync(1);
        Assert.NotNull(enrollment);
        Assert.Equal(1, enrollment.Id);
    }

    [Fact]
    public async Task GetEnrollmentById_ShouldReturnNull_WhenNotExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Enrollment?)null);
        var enrollment = await _service.GetEnrollmentByIdAsync(99);
        Assert.Null(enrollment);
    }

    [Fact]
    public async Task CreateEnrollment_ShouldReturnTrue()
    {
        var dto = new EnrollmentDTO { EnrollmentDate = DateTime.Now, Term = "2025-1", Status = "Enrolled", StudentId = 1, CourseId = 1 };
        _repoMock.Setup(r => r.AddAsync(It.IsAny<Enrollment>())).ReturnsAsync(true);
        Assert.True(await _service.AddEnrollmentAsync(dto));
    }

    [Fact]
    public async Task UpdateEnrollment_ShouldReturnTrue_WhenExists()
    {
        var dto = new EnrollmentDTO { EnrollmentDate = DateTime.Now, Term = "2025-1", Status = "Approved", StudentId = 1, CourseId = 1 };
        _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Enrollment { Id = 1 });
        _repoMock.Setup(r => r.UpdateAsync(It.IsAny<Enrollment>())).ReturnsAsync(true);

        var result = await _service.UpdateEnrollmentAsync(1, dto);
        Assert.True(result);
    }

    [Fact]
    public async Task UpdateEnrollment_ShouldReturnFalse_WhenNotExists()
    {
        var dto = new EnrollmentDTO { EnrollmentDate = DateTime.Now, Term = "2025-1", Status = "Approved", StudentId = 1, CourseId = 1 };
        _repoMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Enrollment?)null);

        var result = await _service.UpdateEnrollmentAsync(99, dto);
        Assert.False(result);
    }

    [Fact]
    public async Task DeleteEnrollment_ShouldReturnTrue_WhenExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Enrollment { Id = 1 });
        _repoMock.Setup(r => r.DeleteAsync(1)).ReturnsAsync(true);

        var result = await _service.DeleteEnrollmentAsync(1);
        Assert.True(result);
    }

    [Fact]
    public async Task DeleteEnrollment_ShouldReturnFalse_WhenNotExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Enrollment?)null);

        var result = await _service.DeleteEnrollmentAsync(99);
        Assert.False(result);
    }
}
