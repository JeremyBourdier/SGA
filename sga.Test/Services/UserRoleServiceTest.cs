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
            context.Database.EnsureDeleted();
            return context;
        }

        private IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AuthMappingProfile>());
            return config.CreateMapper();
        }

        [Fact]
        public async Task AddUserRoleAsync_AddsUserRole()
        {
            using var context = CreateNewContext();
            var repository = new UserRoleRepository(context);
            var mapper = GetMapper();
            var service = new UserRoleService(repository, mapper);

            var userRole = new UserRoleDTO { UserID = 1, RoleID = 1 };

            await service.AddAsync(userRole);

            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(1, result.First().UserID);
            Assert.Equal(1, result.First().RoleID);
        }

        [Fact]
        public async Task GetAllUserRolesAsync_ReturnsAllUserRoles()
        {
            using var context = CreateNewContext();
            var repository = new UserRoleRepository(context);
            var mapper = GetMapper();
            var service = new UserRoleService(repository, mapper);

            var userRoles = new[]
            {
                new UserRole { UserID = 1, RoleID = 1 },
                new UserRole { UserID = 2, RoleID = 2 }
            };

            await context.UserRoles.AddRangeAsync(userRoles);
            await context.SaveChangesAsync();

            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetUserRoleByIdAsync_ReturnsUserRole()
        {
            using var context = CreateNewContext();
            var repository = new UserRoleRepository(context);
            var mapper = GetMapper();
            var service = new UserRoleService(repository, mapper);

            var userRole = new UserRole { UserID = 1, RoleID = 1 };

            await context.UserRoles.AddAsync(userRole);
            await context.SaveChangesAsync();

            var result = await service.GetByIdAsync(1, 1);

            Assert.NotNull(result);
            Assert.Equal(1, result.UserID);
            Assert.Equal(1, result.RoleID);
        }


        [Fact]
        public async Task DeleteUserRoleAsync_RemovesUserRole()
        {
            using var context = CreateNewContext();
            var repository = new UserRoleRepository(context);
            var mapper = GetMapper();
            var service = new UserRoleService(repository, mapper);

            var userRole = new UserRole { UserID = 1, RoleID = 1 };
            await context.UserRoles.AddAsync(userRole);
            await context.SaveChangesAsync();

            await service.DeleteAsync(1, 1);
            var result = await service.GetByIdAsync(1, 1);

            Assert.Null(result);
        }
    }
}
