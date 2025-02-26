using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sga.Data;
using sga.Data.Entities;
using sga.Data.Repositories.Implementations;
using Xunit;

namespace sga.Test.Repositories
{
    public class GenericRepositoryTests
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

        [Fact]
        public async Task AddAsync_ShouldAddEntity()
        {
            using var context = CreateNewContext();
            var repository = new GenericRepository<Course>(context);

            var course = new Course { Code = "TDS-101", Name = "Software Engineering" };
            await repository.AddAsync(course);
            var result = await repository.GetByIdAsync(course.Id); // Obtener por ID generado

            Assert.NotNull(result);
            Assert.Equal("TDS-101", result.Code);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllEntities()
        {
            using var context = CreateNewContext();
            var repository = new GenericRepository<Course>(context);

            await repository.AddAsync(new Course { Code = "TDS-101", Name = "Software Engineering" });
            await repository.AddAsync(new Course { Code = "TDS-102", Name = "Data Science" });

            var result = await repository.GetAllAsync();
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateEntity()
        {
            using var context = CreateNewContext();
            var repository = new GenericRepository<Course>(context);

            var course = new Course { Code = "TDS-101", Name = "Old Name" };
            await repository.AddAsync(course);

            course.Name = "New Name";
            await repository.UpdateAsync(course);

            var updatedCourse = await repository.GetByIdAsync(course.Id);
            Assert.Equal("New Name", updatedCourse.Name);
        }

        [Fact]
        public async Task DeleteAsync_ShouldRemoveEntity()
        {
            using var context = CreateNewContext();
            var repository = new GenericRepository<Course>(context);

            var course = new Course { Code = "TDS-101", Name = "Software Engineering" };
            await repository.AddAsync(course);

            await repository.DeleteAsync(course.Id);
            var result = await repository.GetByIdAsync(course.Id);

            Assert.Null(result);
        }
    }
}
