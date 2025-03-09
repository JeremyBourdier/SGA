using AutoMapper;
using Moq;
using sga.AcademicService.DTOs;
using sga.AcademicService.Repositories.Interfaces;
using sga.AcademicService.Services.Implementations;
using sga.Data.Entities.AcademicService;
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
    public async Task CreateEnrollment_ShouldReturnTrue()
    {
        var dto = new EnrollmentDTO { EnrollmentDate = DateTime.Now, Term = "2025-1", Status = "Enrolled", StudentId = 1, CourseId = 1 };
        _repoMock.Setup(r => r.AddAsync(It.IsAny<Enrollment>())).ReturnsAsync(true);
        Assert.True(await _service.AddEnrollmentAsync(dto));
    }
}
