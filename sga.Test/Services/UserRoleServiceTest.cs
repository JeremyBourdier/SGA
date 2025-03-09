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
    public class UserRoleServiceTests
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

        // 1) ADD
        [Fact]
        public async Task AddUserRoleAsync_AddsUserRole()
        {
            // Arrange
            using var context = CreateNewContext();
            var repository = new UserRoleRepository(context);
            var mapper = GetMapper();
            var service = new UserRoleService(repository, mapper);

            var dto = new UserRoleDTO { UserID = 1, RoleID = 1 };

            // Act
            await service.AddAsync(dto);

            // Assert
            var result = await service.GetAllAsync();
            Assert.Single(result);
            Assert.Equal(1, result.First().UserID);
            Assert.Equal(1, result.First().RoleID);
        }

        // 2) GETALL
        [Fact]
        public async Task GetAllUserRolesAsync_ReturnsAllUserRoles()
        {
            // Arrange
            using var context = CreateNewContext();
            context.UserRoles.AddRange(
                new UserRole { UserID = 1, RoleID = 1 },
                new UserRole { UserID = 2, RoleID = 2 }
            );
            await context.SaveChangesAsync();

            var repo = new UserRoleRepository(context);
            var mapper = GetMapper();
            var service = new UserRoleService(repo, mapper);

            // Act
            var result = await service.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        // 3) GETBYID (existe)
        [Fact]
        public async Task GetUserRoleByIdAsync_ReturnsUserRole()
        {
            // Arrange
            using var context = CreateNewContext();
            context.UserRoles.Add(new UserRole { UserID = 10, RoleID = 20 });
            await context.SaveChangesAsync();

            var repo = new UserRoleRepository(context);
            var mapper = GetMapper();
            var service = new UserRoleService(repo, mapper);

            // Act
            var result = await service.GetByIdAsync(10, 20);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(10, result.UserID);
            Assert.Equal(20, result.RoleID);
        }

        // 3b) GETBYID (no encontrado)
        [Fact]
        public async Task GetUserRoleByIdAsync_ReturnsNullIfNotFound()
        {
            // Arrange
            using var context = CreateNewContext();
            var service = new UserRoleService(new UserRoleRepository(context), GetMapper());

            // Act
            var result = await service.GetByIdAsync(999, 999);

            // Assert
            Assert.Null(result);
        }

        // 4) DELETE (existe)
        [Fact]
        public async Task DeleteUserRoleAsync_RemovesUserRole()
        {
            // Arrange
            using var context = CreateNewContext();
            context.UserRoles.Add(new UserRole { UserID = 1, RoleID = 1 });
            await context.SaveChangesAsync();

            var repo = new UserRoleRepository(context);
            var mapper = GetMapper();
            var service = new UserRoleService(repo, mapper);

            // Act
            await service.DeleteAsync(1, 1);

            // Assert
            var result = await service.GetByIdAsync(1, 1);
            Assert.Null(result);
        }

        // 4b) DELETE (no encontrado)
        [Fact]
        public async Task DeleteUserRoleAsync_ReturnsNoEffectIfNotFound()
        {
            // Arrange
            using var context = CreateNewContext();
            var service = new UserRoleService(new UserRoleRepository(context), GetMapper());

            // Act
            // Se intenta borrar un UserRole que no existe
            await service.DeleteAsync(999, 999);

            // Assert
            // Verifica que no haya crasheado y que la BD siga vacía
            var all = context.UserRoles.ToList();
            Assert.Empty(all);
        }
    }
}
