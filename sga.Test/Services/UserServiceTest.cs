using AutoMapper;
using Moq;
using sga.AcademicService.DTOs;
using sga.AcademicService.Mapping;
using sga.AcademicService.Repositories.Interfaces;
using sga.AcademicService.Services.Implementations;
using sga.Data.Entities.AcademicService;
using Xunit;

namespace sga.AcademicService.Tests
{
    public class TeacherServiceTests
    {
        private readonly TeacherService _service;
        private readonly Mock<ITeacherRepository> _repoMock;
        private readonly IMapper _mapper;

        public TeacherServiceTests()
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            _mapper = mappingConfig.CreateMapper();
            _repoMock = new Mock<ITeacherRepository>();
            _service = new TeacherService(_repoMock.Object, _mapper);
        }

        [Fact]
        public async Task GetAllTeachersAsync_ShouldReturnAllTeachers()
        {
            _repoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<Teacher> { new Teacher { Id = 1 } });
            var result = await _service.GetAllTeachersAsync();

            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task GetTeacherByIdAsync_ExistingId_ShouldReturnTeacher()
        {
            _repoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(new Teacher { Id = 1 });

            var result = await _service.GetTeacherByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetTeacherByIdAsync_NonExistingId_ShouldReturnNull()
        {
            _repoMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Teacher?)null);

            var result = await _service.GetTeacherByIdAsync(99);

            Assert.Null(result);
        }

        [Fact]
        public async Task AddTeacherAsync_ShouldReturnTrue_WhenTeacherIsValid()
        {
            var teacherDto = new TeacherDTO { UserId = 2, Department = "Math", Specialty = "Algebra" };

            _repoMock.Setup(repo => repo.AddAsync(It.IsAny<Teacher>())).ReturnsAsync(true);

            var result = await _service.AddTeacherAsync(teacherDto);

            Assert.True(result);
        }

        [Fact]
        public async Task UpdateTeacherAsync_ShouldReturnTrue_WhenTeacherExists()
        {
            var teacherDto = new TeacherDTO { Id = 1, UserId = 2, Department = "Science", Specialty = "Biology" };
            _repoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(new Teacher { Id = 1 });

            var result = await _service.UpdateTeacherAsync(1, teacherDto);

            Assert.True(result);
        }

        [Fact]
        public async Task UpdateTeacherAsync_ShouldReturnFalse_WhenTeacherDoesNotExist()
        {
            var teacherDto = new TeacherDTO { Id = 99, UserId = 3 };
            _repoMock.Setup(repo => repo.GetByIdAsync(99)).ReturnsAsync((Teacher?)null);

            var result = await _service.UpdateTeacherAsync(99, teacherDto);

            Assert.False(result);
        }

        [Fact]
        public async Task DeleteTeacherAsync_ShouldReturnTrue_WhenTeacherExists()
        {
            _repoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(new Teacher { Id = 1 });
            _repoMock.Setup(repo => repo.DeleteAsync(1)).ReturnsAsync(true);

            var result = await _service.DeleteTeacherAsync(1);

            Assert.True(result);
        }

        [Fact]
        public async Task DeleteTeacherAsync_ShouldReturnFalse_WhenTeacherDoesNotExist()
        {
            _repoMock.Setup(repo => repo.GetByIdAsync(99)).ReturnsAsync((Teacher?)null);

            var result = await _service.DeleteTeacherAsync(99);

            Assert.False(result);
        }
    }
}
