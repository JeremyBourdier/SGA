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
    public class RolePermissionServiceTests
    {
        private AuthDbContext CreateNewContext()
        {
            var options = new DbContextOptionsBuilder<AuthDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var ctx = new AuthDbContext(options);
            ctx.Database.EnsureDeleted();
            return ctx;
        }

        private IMapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<AuthMappingProfile>());
            return cfg.CreateMapper();
        }

        [Fact]
        public async Task AddAsync_AddsRolePermission()
        {
            using var context = CreateNewContext();
            var repo = new RolePermissionRepository(context);
            var mapper = GetMapper();
            var service = new RolePermissionService(repo, mapper);

            // Insertar un Role y un Permission para simular la relación
            context.Roles.Add(new Role { Id = 1, Name = "Admin", Description = "Rol de Prueba" });
            context.Permissions.Add(new Permission { Id = 100, Name = "Read", Description = "Permiso de prueba" });
            await context.SaveChangesAsync();

            var dto = new RolePermissionDTO
            {
                RoleID = 1,
                PermissionID = 100
            };

            var success = await service.AddAsync(dto);
            Assert.True(success);

            var all = context.RolePermissions.ToList();
            Assert.Single(all);
            Assert.Equal(1, all[0].RoleID);
            Assert.Equal(100, all[0].PermissionID);
        }

        [Fact]
        public async Task DeleteAsync_DeletesRolePermission()
        {
            using var context = CreateNewContext();
            var repo = new RolePermissionRepository(context);
            var mapper = GetMapper();
            var service = new RolePermissionService(repo, mapper);

            // Insertar un RolePermission
            context.RolePermissions.Add(new RolePermission { RoleID = 2, PermissionID = 200 });
            await context.SaveChangesAsync();

            // Act
            var success = await service.DeleteAsync(2, 200);

            // Assert
            Assert.True(success);
            Assert.Empty(context.RolePermissions);
        }
    }
}
