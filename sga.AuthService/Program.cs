using Microsoft.EntityFrameworkCore;
using sga.Data;            // Donde est� AuthDbContext
using sga.AuthService.Mapping;
using sga.AuthService.Repositories.Interfaces;
using sga.AuthService.Repositories.Implementations;
using sga.AuthService.Services.Interfaces;
using sga.AuthService.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuraci�n de DbContext para AuthDBConnection
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AuthDBConnection")
    )
);

// 2. Registrar AutoMapper con el perfil de AuthMappingProfile
builder.Services.AddAutoMapper(typeof(AuthMappingProfile));

// 3. Registrar Repositorios y Servicios
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IPermissionService, PermissionService>();

builder.Services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
builder.Services.AddScoped<IRolePermissionService, RolePermissionService>();

// 4. Agregar controladores y swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuraci�n del pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();
