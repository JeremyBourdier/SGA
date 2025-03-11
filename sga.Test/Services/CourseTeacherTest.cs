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

public class CourseTeacherServiceTests
{
    private readonly CourseTeacherService _service;
    private readonly Mock<ICourseTeacherRepository> _repoMock;
    private readonly IMapper _mapper;

    public CourseTeacherServiceTests()
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CourseTeacher, CourseTeacherDTO>().ReverseMap();
        });

        _mapper = mapperConfig.CreateMapper();
        _repoMock = new Mock<ICourseTeacherRepository>();
        _service = new CourseTeacherService(_repoMock.Object, _mapper);
    }

    [Fact]
    public async Task GetAllCourseTeachers_ShouldReturnList()
    {
        _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<CourseTeacher> { new CourseTeacher { Id = 1 } });
        var courseTeachers = await _service.GetAllCourseTeachersAsync();
        Assert.Single(courseTeachers);
    }

    [Fact]
    public async Task GetCourseTeacherById_ShouldReturnCourseTeacher_WhenExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new CourseTeacher { Id = 1 });
        var courseTeacher = await _service.GetCourseTeacherByIdAsync(1);
        Assert.NotNull(courseTeacher);
        Assert.Equal(1, courseTeacher.Id);
    }

    [Fact]
    public async Task GetCourseTeacherById_ShouldReturnNull_WhenNotExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((CourseTeacher?)null);
        var courseTeacher = await _service.GetCourseTeacherByIdAsync(99);
        Assert.Null(courseTeacher);
    }

    [Fact]
    public async Task CreateCourseTeacher_ShouldReturnTrue()
    {
        var dto = new CourseTeacherDTO { CourseId = 1, TeacherId = 1, AssignmentDate = DateTime.Now };
        _repoMock.Setup(r => r.AddAsync(It.IsAny<CourseTeacher>())).ReturnsAsync(true);
        Assert.True(await _service.AddCourseTeacherAsync(dto));
    }

    [Fact]
    public async Task UpdateCourseTeacher_ShouldReturnTrue_WhenExists()
    {
        var dto = new CourseTeacherDTO { CourseId = 2, TeacherId = 1, AssignmentDate = DateTime.Now };
        _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new CourseTeacher { Id = 1 });
        _repoMock.Setup(r => r.UpdateAsync(It.IsAny<CourseTeacher>())).ReturnsAsync(true);

        var result = await _service.UpdateCourseTeacherAsync(1, dto);
        Assert.True(result);
    }

    [Fact]
    public async Task UpdateCourseTeacher_ShouldReturnFalse_WhenNotExists()
    {
        var dto = new CourseTeacherDTO { CourseId = 2, TeacherId = 1, AssignmentDate = DateTime.Now };
        _repoMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((CourseTeacher?)null);

        var result = await _service.UpdateCourseTeacherAsync(99, dto);
        Assert.False(result);
    }

    [Fact]
    public async Task DeleteCourseTeacher_ShouldReturnTrue_WhenExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new CourseTeacher { Id = 1 });
        _repoMock.Setup(r => r.DeleteAsync(1)).ReturnsAsync(true);

        var result = await _service.DeleteCourseTeacherAsync(1);
        Assert.True(result);
    }

    [Fact]
    public async Task DeleteCourseTeacher_ShouldReturnFalse_WhenNotExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((CourseTeacher?)null);

        var result = await _service.DeleteCourseTeacherAsync(99);
        Assert.False(result);
    }
}
