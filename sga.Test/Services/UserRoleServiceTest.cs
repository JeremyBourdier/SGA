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
    }
}
