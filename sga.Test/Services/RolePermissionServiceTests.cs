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
    public class RolePermissionServiceTests
    {
        private AuthDbContext CreateNewContext()
        {
            var options = new DbContextOptionsBuilder<AuthDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var ctx = new AuthDbContext(options);
            // Limpia la BD en memoria antes de cada test
            ctx.Database.EnsureDeleted();
            return ctx;
        }

        private IMapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<AuthMappingProfile>());
            return cfg.CreateMapper();
        }

        // 1) ADD
        [Fact]
        public async Task AddAsync_AddsRolePermission()
        {
            // Arrange
            using var context = CreateNewContext();
            var repo = new RolePermissionRepository(context);
            var mapper = GetMapper();
            var service = new RolePermissionService(repo, mapper);

            // Insertar un Role y un Permission para la relación
            context.Roles.Add(new Role { Id = 1, Name = "Admin", Description = "Rol de Prueba" });
            context.Permissions.Add(new Permission { Id = 100, Name = "Read", Description = "Permiso de prueba" });
            await context.SaveChangesAsync();

            var dto = new RolePermissionDTO
            {
                RoleID = 1,
                PermissionID = 100
            };

            // Act
            var success = await service.AddAsync(dto);

            // Assert
            Assert.True(success, "Debe retornar true si se insertó la relación.");
            var all = context.RolePermissions.ToList();
            Assert.Single(all);
            Assert.Equal(1, all[0].RoleID);
            Assert.Equal(100, all[0].PermissionID);
        }

        // 2) GETALL
        [Fact]
        public async Task GetAllAsync_ReturnsAllRolePermissions()
        {
            // Arrange
            using var context = CreateNewContext();
            var repo = new RolePermissionRepository(context);
            var mapper = GetMapper();
            var service = new RolePermissionService(repo, mapper);

            context.RolePermissions.AddRange(
                new RolePermission { RoleID = 1, PermissionID = 100 },
                new RolePermission { RoleID = 2, PermissionID = 200 }
            );
            await context.SaveChangesAsync();

            // Act
            var result = await service.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        // 3) GETBYIDS (existe)
        [Fact]
        public async Task GetByIdsAsync_ReturnsCorrectRolePermission()
        {
            // Arrange
            using var context = CreateNewContext();
            context.RolePermissions.Add(new RolePermission { RoleID = 3, PermissionID = 300 });
            await context.SaveChangesAsync();

            var repo = new RolePermissionRepository(context);
            var mapper = GetMapper();
            var service = new RolePermissionService(repo, mapper);

            // Act
            var dto = await service.GetByIdsAsync(3, 300);

            // Assert
            Assert.NotNull(dto);
            Assert.Equal(3, dto.RoleID);
            Assert.Equal(300, dto.PermissionID);
        }

        // 3b) GETBYIDS (no encontrado)
        [Fact]
        public async Task GetByIdsAsync_ReturnsNullIfNotFound()
        {
            // Arrange
            using var context = CreateNewContext();
            var service = new RolePermissionService(
                new RolePermissionRepository(context),
                GetMapper()
            );

            // Act
            var dto = await service.GetByIdsAsync(999, 999);

            // Assert
            Assert.Null(dto);
        }

        // 4) DELETE (existe)
        [Fact]
        public async Task DeleteAsync_DeletesRolePermission()
        {
            // Arrange
            using var context = CreateNewContext();
            var repo = new RolePermissionRepository(context);
            var mapper = GetMapper();
            var service = new RolePermissionService(repo, mapper);

            context.RolePermissions.Add(new RolePermission { RoleID = 2, PermissionID = 200 });
            await context.SaveChangesAsync();

            // Act
            var success = await service.DeleteAsync(2, 200);

            // Assert
            Assert.True(success, "Debe retornar true si existía la relación.");
            Assert.Empty(context.RolePermissions);
        }

        // 4b) DELETE (no encontrado)
        [Fact]
        public async Task DeleteAsync_ReturnsFalseIfNotFound()
        {
            // Arrange
            using var context = CreateNewContext();
            var service = new RolePermissionService(
                new RolePermissionRepository(context),
                GetMapper()
            );

            // Act
            var success = await service.DeleteAsync(999, 999);

            // Assert
            Assert.False(success, "Debe retornar false si no encuentra la relación a eliminar.");
        }
    }
}
