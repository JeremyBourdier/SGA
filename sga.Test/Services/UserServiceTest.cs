using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using sga.Data;                       // Donde está AuthDbContext
using sga.Data.Entities;             // Donde está la entidad User
using sga.AuthService.DTOs;
using sga.AuthService.Mapping;       // Donde está AuthMappingProfile
using sga.AuthService.Repositories.Implementations;
using sga.AuthService.Services.Implementations;
using Xunit;

namespace sga.Test.Services
{
    public class UserServiceTests
    {
        // Crea un AuthDbContext en memoria para cada prueba
        private AuthDbContext CreateNewContext()
        {
            var options = new DbContextOptionsBuilder<AuthDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // BD única por prueba
                .Options;

            var context = new AuthDbContext(options);
            context.Database.EnsureDeleted(); // Limpia la BD antes de cada prueba
            return context;
        }

        // Configura AutoMapper con el perfil de Auth
        private IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AuthMappingProfile>());
            return config.CreateMapper();
        }

        [Fact]
        public async Task GetAllUsers_ReturnsUsers()
        {
            // Arrange
            using var context = CreateNewContext();
            var userRepository = new UserRepository(context);
            var mapper = GetMapper();
            var userService = new UserService(userRepository, mapper);

            // Insertar un usuario de prueba en la base de datos en memoria
            var user = new User
            {
                Fullname = "John Doe",
                Email = "john@example.com",
                PasswordHash = "hash123",
                Status = "active"
            };
            context.Users.Add(user);
            await context.SaveChangesAsync();

            // Act
            var result = await userService.GetAllUsersAsync();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result); // solo hay 1 en la BD
            Assert.Equal("John Doe", result.First().Fullname);
            Assert.Equal("john@example.com", result.First().Email);
        }

        [Fact]
        public async Task AddUserAsync_AddsUserCorrectly()
        {
            // Arrange
            using var context = CreateNewContext();
            var userRepository = new UserRepository(context);
            var mapper = GetMapper();
            var userService = new UserService(userRepository, mapper);

            var userDto = new UserDTO
            {
                Fullname = "Jane Smith",
                Email = "jane@example.com",
                PasswordHash = "hash456",
                Status = "active"
            };

            // Act
            var success = await userService.AddUserAsync(userDto);

            // Assert
            Assert.True(success);

            var allUsers = await context.Users.ToListAsync();
            Assert.Single(allUsers); // Debería haber 1
            Assert.Equal("Jane Smith", allUsers[0].Fullname);
        }

        [Fact]
        public async Task GetUserByIdAsync_ReturnsNull_IfNotFound()
        {
            // Arrange
            using var context = CreateNewContext();
            var userRepository = new UserRepository(context);
            var mapper = GetMapper();
            var userService = new UserService(userRepository, mapper);

            // No insertamos nada en la BD

            // Act
            var result = await userService.GetUserByIdAsync(99);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateUserAsync_ReturnsFalse_IfUserDoesNotExist()
        {
            // Arrange
            using var context = CreateNewContext();
            var userRepository = new UserRepository(context);
            var mapper = GetMapper();
            var userService = new UserService(userRepository, mapper);

            var userDto = new UserDTO
            {
                Id = 999,
                Fullname = "Non-Existent",
                Email = "nope@example.com"
            };

            // Act
            var success = await userService.UpdateUserAsync(999, userDto);

            // Assert
            Assert.False(success);
        }

        [Fact]
        public async Task DeleteUserAsync_RemovesUser()
        {
            // Arrange
            using var context = CreateNewContext();
            var userRepository = new UserRepository(context);
            var mapper = GetMapper();
            var userService = new UserService(userRepository, mapper);

            // Insertar un usuario con todos los campos requeridos
            var user = new User
            {
                Fullname = "ToDelete",
                Email = "delete@example.com",
                PasswordHash = "test-hash", 
                Status = "active"           
            };
            context.Users.Add(user);
            await context.SaveChangesAsync();

            // Act
            var success = await userService.DeleteUserAsync(user.Id);

            // Assert
            Assert.True(success);

            var allUsers = await context.Users.ToListAsync();
            Assert.Empty(allUsers); // Se borró
        }
    }
}
