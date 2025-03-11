using AutoMapper;
using Microsoft.EntityFrameworkCore;
using sga.AuthService.DTOs;
using sga.AuthService.Mapping;
using sga.AuthService.Repositories.Implementations;
using sga.AuthService.Services.Implementations;
using sga.Data;
using sga.Data.Entities.AuthService;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace sga.Test.Services
{
    public class PermissionServiceTests
    {
        private AuthDbContext CreateNewContext()
        {
            var options = new DbContextOptionsBuilder<AuthDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new AuthDbContext(options);
            // Limpia la BD en memoria antes de cada test
            context.Database.EnsureDeleted();
            return context;
        }

        private IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AuthMappingProfile>());
            return config.CreateMapper();
        }

        // 1) CREATE
        [Fact]
        public async Task AddPermissionAsync_AddsPermissionCorrectly()
        {
            // Arrange
            using var context = CreateNewContext();
            var repo = new PermissionRepository(context);
            var mapper = GetMapper();
            var service = new PermissionService(repo, mapper);

            var dto = new PermissionDTO
            {
                Name = "Write",
                Description = "Allows write operations"
            };

            // Act
            var success = await service.AddPermissionAsync(dto);

            // Assert
            Assert.True(success, "Debería retornar true si la inserción fue exitosa.");
            var permsInDb = context.Permissions.ToList();
            Assert.Single(permsInDb);
            Assert.Equal("Write", permsInDb[0].Name);
            Assert.Equal("Allows write operations", permsInDb[0].Description);
        }

        // 2) READ (GetAll)
        [Fact]
        public async Task GetAllPermissionsAsync_ReturnsAllPermissions()
        {
            // Arrange
            using var context = CreateNewContext();
            context.Permissions.AddRange(
                new Permission { Id = 1, Name = "Read", Description = "Desc read" },
                new Permission { Id = 2, Name = "Edit", Description = "Desc edit" }
            );
            await context.SaveChangesAsync();

            var repo = new PermissionRepository(context);
            var mapper = GetMapper();
            var service = new PermissionService(repo, mapper);

            // Act
            var result = await service.GetAllPermissionsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, p => p.Name == "Read");
            Assert.Contains(result, p => p.Name == "Edit");
        }

        // 3) READ (GetById)
        [Fact]
        public async Task GetPermissionByIdAsync_ReturnsCorrectPermission()
        {
            // Arrange
            using var context = CreateNewContext();
            context.Permissions.Add(new Permission { Id = 99, Name = "Delete", Description = "Desc delete" });
            await context.SaveChangesAsync();

            var repo = new PermissionRepository(context);
            var mapper = GetMapper();
            var service = new PermissionService(repo, mapper);

            // Act
            var dto = await service.GetPermissionByIdAsync(99);

            // Assert
            Assert.NotNull(dto);
            Assert.Equal("Delete", dto.Name);
            Assert.Equal("Desc delete", dto.Description);
        }

       
        // 4b) UPDATE (not found)
        [Fact]
        public async Task UpdatePermissionAsync_ReturnsFalseIfNotFound()
        {
            // Arrange
            using var context = CreateNewContext();
            var service = new PermissionService(new PermissionRepository(context), GetMapper());

            var dto = new PermissionDTO { Name = "NonExistent" };

            // Act
            var success = await service.UpdatePermissionAsync(999, dto);

            // Assert
            Assert.False(success, "Debe retornar false si el permiso no existe.");
        }

        // 5) DELETE (success)
        [Fact]
        public async Task DeletePermissionAsync_DeletesCorrectly()
        {
            // Arrange
            using var context = CreateNewContext();
            var repo = new PermissionRepository(context);
            var mapper = GetMapper();
            var service = new PermissionService(repo, mapper);

            context.Permissions.Add(new Permission { Id = 222, Name = "ToDelete", Description = "DescDel" });
            await context.SaveChangesAsync();

            // Act
            var success = await service.DeletePermissionAsync(222);

            // Assert
            Assert.True(success, "Debe retornar true si existía el permiso para eliminar.");
            Assert.Empty(context.Permissions);
        }

        // 5b) DELETE (not found)
        [Fact]
        public async Task DeletePermissionAsync_ReturnsFalseIfNotFound()
        {
            // Arrange
            using var context = CreateNewContext();
            var service = new PermissionService(new PermissionRepository(context), GetMapper());

            // Act
            var success = await service.DeletePermissionAsync(888); // no existe

            // Assert
            Assert.False(success, "Debe retornar false si no se encuentra el permiso a eliminar.");
        }
    }
}
