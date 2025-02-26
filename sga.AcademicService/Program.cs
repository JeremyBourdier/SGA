using sga.Data;
using sga.AcademicService.Repositories.Interfaces;
using sga.AcademicService.Repositories.Implementations;
using sga.AcademicService.Services.Interfaces;
using sga.AcademicService.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using sga.AcademicService.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Configuración de conexión a la base de datos
builder.Services.AddDbContext<AcademicDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AcademicDBConnection")));

// Configuración de AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Configuración de inyección de dependencias
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();

// Habilita controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:3000") // Cambia según el dominio de React
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
