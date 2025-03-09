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
    public class RoleServiceTests
    {
        private AuthDbContext CreateNewContext()
        {
            var options = new DbContextOptionsBuilder<AuthDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new AuthDbContext(options);
            // Limpia la BD en memoria antes de cada prueba
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
        public async Task AddRoleAsync_AddsRoleCorrectly()
        {
            // Arrange
            using var context = CreateNewContext();
            var repo = new RoleRepository(context);
            var mapper = GetMapper();
            var service = new RoleService(repo, mapper);

            var roleDto = new RoleDTO
            {
                Name = "Administrator",
                Description = "Full Access"
            };

            // Act
            var success = await service.AddRoleAsync(roleDto);

            // Assert
            Assert.True(success, "Debe retornar true si se insertó con éxito.");
            var rolesInDb = context.Roles.ToList();
            Assert.Single(rolesInDb);
            Assert.Equal("Administrator", rolesInDb[0].Name);
            Assert.Equal("Full Access", rolesInDb[0].Description);
        }

        // 2) READ (GetAll)
        [Fact]
        public async Task GetAllRolesAsync_ReturnsAllRoles()
        {
            // Arrange
            using var context = CreateNewContext();
            context.Roles.Add(new Role { Id = 10, Name = "Admin", Description = "desc" });
            context.Roles.Add(new Role { Id = 11, Name = "Editor", Description = "desc2" });
            await context.SaveChangesAsync();

            var repo = new RoleRepository(context);
            var mapper = GetMapper();
            var service = new RoleService(repo, mapper);

            // Act
            var roles = await service.GetAllRolesAsync();

            // Assert
            Assert.NotNull(roles);
            Assert.Equal(2, roles.Count());
            Assert.Contains(roles, r => r.Name == "Admin");
            Assert.Contains(roles, r => r.Name == "Editor");
        }

        // 3) READ (GetById) => existe
        [Fact]
        public async Task GetRoleByIdAsync_ReturnsCorrectRole()
        {
            // Arrange
            using var context = CreateNewContext();
            context.Roles.Add(new Role { Id = 99, Name = "Tester", Description = "Desc test" });
            await context.SaveChangesAsync();

            var repo = new RoleRepository(context);
            var mapper = GetMapper();
            var service = new RoleService(repo, mapper);

            // Act
            var dto = await service.GetRoleByIdAsync(99);

            // Assert
            Assert.NotNull(dto);
            Assert.Equal("Tester", dto.Name);
            Assert.Equal("Desc test", dto.Description);
        }

        // 3b) READ (GetById) => no encontrado
        [Fact]
        public async Task GetRoleByIdAsync_ReturnsNullIfNotFound()
        {
            // Arrange
            using var context = CreateNewContext();
            var service = new RoleService(new RoleRepository(context), GetMapper());

            // Act
            var dto = await service.GetRoleByIdAsync(777); // no existe

            // Assert
            Assert.Null(dto);
        }

        // 4) UPDATE (existe)
        [Fact]
        public async Task UpdateRoleAsync_UpdatesExistingRole()
        {
            // Arrange
            using var context = CreateNewContext();
            context.Roles.Add(new Role { Id = 123, Name = "Original", Description = "OriginalDesc" });
            await context.SaveChangesAsync();

            var repo = new RoleRepository(context);
            var mapper = GetMapper();
            var service = new RoleService(repo, mapper);

            var dtoToUpdate = new RoleDTO
            {
                Name = "UpdatedName",
                Description = "UpdatedDesc"
            };

            // Act
            var success = await service.UpdateRoleAsync(123, dtoToUpdate);

            // Assert
            Assert.True(success, "Debe retornar true si existía el rol pero no existe xd");
            var updated = context.Roles.Find(123);
            Assert.Equal("UpdatedName", updated?.Name);
            Assert.Equal("UpdatedDesc", updated?.Description);
        }

        // 4b) UPDATE (no encontrado)
        [Fact]
        public async Task UpdateRoleAsync_ReturnsFalseIfNotFound()
        {
            // Arrange
            using var context = CreateNewContext();
            var service = new RoleService(new RoleRepository(context), GetMapper());

            var dto = new RoleDTO { Name = "Whatever" };

            // Act
            var success = await service.UpdateRoleAsync(999, dto);

            // Assert
            Assert.False(success, "Debe retornar false si no existe el rol para actualizar.");
        }

        // 5) DELETE (existe)
        [Fact]
        public async Task DeleteRoleAsync_RemovesRole()
        {
            // Arrange
            using var context = CreateNewContext();
            var repo = new RoleRepository(context);
            var mapper = GetMapper();
            var service = new RoleService(repo, mapper);

            var role = new Role { Id = 555, Name = "Temp", Description = "To delete" };
            context.Roles.Add(role);
            await context.SaveChangesAsync();

            // Act
            var success = await service.DeleteRoleAsync(555);

            // Assert
            Assert.True(success, "Debe retornar true si el rol existía y se eliminó.");
            Assert.Empty(context.Roles);
        }

        // 5b) DELETE (no encontrado)
        [Fact]
        public async Task DeleteRoleAsync_ReturnsFalseIfNotFound()
        {
            // Arrange
            using var context = CreateNewContext();
            var service = new RoleService(new RoleRepository(context), GetMapper());

            // Act
            var success = await service.DeleteRoleAsync(7777); // no existe

            // Assert
            Assert.False(success, "Debe retornar false si el rol no existe para eliminar.");
        }
    }
}
