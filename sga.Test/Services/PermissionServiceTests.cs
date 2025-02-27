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
    public class PermissionServiceTests
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
        public async Task AddPermissionAsync_AddsPermissionCorrectly()
        {
            using var context = CreateNewContext();
            var repo = new PermissionRepository(context);
            var mapper = GetMapper();
            var service = new PermissionService(repo, mapper);

            var dto = new PermissionDTO
            {
                Name = "Write",
                Description = "Allows write operations"
            };

            var success = await service.AddPermissionAsync(dto);

            Assert.True(success);
            var permsInDb = context.Permissions.ToList();
            Assert.Single(permsInDb);
            Assert.Equal("Write", permsInDb[0].Name);
        }

        
    }
}
