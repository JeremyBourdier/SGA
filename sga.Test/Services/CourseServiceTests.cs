using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using sga.Data;
using sga.Data.Entities;
using sga.AcademicService.Repositories.Implementations;
using sga.AcademicService.Services.Implementations;
using sga.AcademicService.DTOs;
using sga.AcademicService.Mapping;
using Xunit;

public class CourseServiceTests
{
    private AcademicDbContext CreateNewContext()
    {
        var options = new DbContextOptionsBuilder<AcademicDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Base de datos única por prueba
            .Options;

        var context = new AcademicDbContext(options);
        context.Database.EnsureDeleted(); // Limpia la base de datos antes de cada prueba
        return context;
    }

    private IMapper GetMapper()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        return config.CreateMapper();
    }

    [Fact]
    public async Task GetAllCourses_ReturnsCourses()
    {
        using var context = CreateNewContext();
        var repository = new CourseRepository(context);
        var mapper = GetMapper();
        var service = new CourseService(repository, mapper);

        // Arrange
        var course = new Course { Code = "MAT101", Name = "Math", Credits = 4 };
        context.Courses.Add(course);
        await context.SaveChangesAsync();

        // Act
        var result = await service.GetAllCoursesAsync();

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Single(result);
        Assert.Equal("Math", result.First().Name);
    }
}
