using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using sga.Data;
using sga.AcademicService.Repositories.Interfaces;
using sga.AcademicService.Repositories.Implementations;
using sga.AcademicService.Services.Interfaces;
using sga.AcademicService.Services.Implementations;
using sga.AcademicService.Mapping;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Configuración de conexión a la base de datos
builder.Services.AddDbContext<AcademicDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AcademicDBConnection")));

// Configuración de AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Configuración de inyección de dependencias
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();

// Habilitación de CORS para el frontend en Vite (React)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:5174", "https://localhost:5174") //Front usa este puerto
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

// Habilita controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware de Seguridad
app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers(); // Asegura que los controladores estén disponibles

// Configuración para servir el frontend
var frontendPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "sga.Client", "dist");
if (Directory.Exists(frontendPath))
{
    app.UseDefaultFiles(); // Permite servir `index.html` por defecto
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(frontendPath),
        RequestPath = ""
    });

    // Redirige todas las rutas al index.html de React para manejar rutas del frontend
    app.MapFallbackToFile("index.html", frontendPath);
}

app.Run();
