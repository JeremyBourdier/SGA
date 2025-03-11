using AutoMapper;
using Moq;
using sga.AcademicService.DTOs;
using sga.AcademicService.Mapping;
using sga.AcademicService.Repositories.Interfaces;
using sga.AcademicService.Services.Implementations;
using sga.Data.Entities.AcademicService;

public class StudentServiceTests
{
    private readonly Mock<IStudentRepository> _repoMock;
    private readonly IMapper _mapper;
    private readonly StudentService _service;

    public StudentServiceTests()
    {
        var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
        _mapper = mapperConfig.CreateMapper();
        _repoMock = new Mock<IStudentRepository>();
        _service = new StudentService(_repoMock.Object, _mapper);
    }

    [Fact]
    public async Task GetAllStudentsAsync_ShouldReturnList()
    {
        _repoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<Student> { new Student() });
        var students = await _service.GetAllStudentsAsync();
        Assert.Single(students);
    }

    [Fact]
    public async Task CreateStudent_ShouldReturnTrue_WhenValid()
    {
        var studentDto = new StudentDTO { UserId = 1, DegreeId = 1 };
        _repoMock.Setup(repo => repo.AddAsync(It.IsAny<Student>())).ReturnsAsync(true);
        Assert.True(await _service.AddStudentAsync(studentDto));
    }

    [Fact]
    public async Task UpdateStudent_ShouldReturnTrue_WhenExists()
    {
        var studentDto = new StudentDTO { UserId = 1, DegreeId = 2 };
        _repoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(new Student { Id = 1 });
        _repoMock.Setup(repo => repo.UpdateAsync(It.IsAny<Student>())).ReturnsAsync(true);

        var result = await _service.UpdateStudentAsync(1, studentDto);

        Assert.True(result);
    }

    [Fact]
    public async Task DeleteStudent_ShouldReturnFalse_WhenNonExistentId()
    {
        _repoMock.Setup(repo => repo.GetByIdAsync(99)).ReturnsAsync((Student?)null);

        var result = await _service.DeleteStudentAsync(99);

        Assert.False(result);
    }
}

