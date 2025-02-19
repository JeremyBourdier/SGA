using Microsoft.EntityFrameworkCore;
using sga.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// 1) Obtener las cadenas de conexión
var authConnectionString = builder.Configuration.GetConnectionString("AuthDBConnection");

var academicConnectionString = builder.Configuration.GetConnectionString("AcademicDBConnection");

// 2) Agregar los DbContext con SQL Server
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(authConnectionString));

builder.Services.AddDbContext<AcademicDbContext>(options =>
    options.UseSqlServer(academicConnectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
