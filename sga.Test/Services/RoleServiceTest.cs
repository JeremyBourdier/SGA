using AutoMapper;
using Microsoft.EntityFrameworkCore;
using sga.AuthService.DTOs;
using sga.AuthService.Mapping;
using sga.AuthService.Repositories.Implementations;
using sga.AuthService.Services.Implementations;
using sga.Data;
using sga.Data.Entities;
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
            context.Database.EnsureDeleted();
            return context;
        }

        private IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AuthMappingProfile>());
            return config.CreateMapper();
        }

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
            Assert.True(success);

            var rolesInDb = context.Roles.ToList();
            Assert.Single(rolesInDb);
            Assert.Equal("Administrator", rolesInDb[0].Name);
        }

        [Fact]
        public async Task GetAllRoles_ReturnsAllRoles()
        {
            // Arrange
            using var context = CreateNewContext();
            var repo = new RoleRepository(context);
            var mapper = GetMapper();
            var service = new RoleService(repo, mapper);

            // Insert role
            context.Roles.Add(new Role { Name = "Admin", Description = "desc" });
            await context.SaveChangesAsync();

            // Act
            var roles = await service.GetAllRolesAsync();

            // Assert
            Assert.Single(roles);
            Assert.Equal("Admin", roles.First().Name);
        }

        [Fact]
        public async Task DeleteRoleAsync_RemovesRole()
        {
            // Arrange
            using var context = CreateNewContext();
            var repo = new RoleRepository(context);
            var mapper = GetMapper();
            var service = new RoleService(repo, mapper);

            var role = new Role { Name = "Temp", Description = "To delete" };
            context.Roles.Add(role);
            await context.SaveChangesAsync();

            // Act
            var success = await service.DeleteRoleAsync(role.Id);

            // Assert
            Assert.True(success);
            Assert.Empty(context.Roles);
        }
    }
}
