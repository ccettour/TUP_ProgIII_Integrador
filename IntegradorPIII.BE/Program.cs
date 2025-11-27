using Microsoft.EntityFrameworkCore;
using IntegradorPIII.BE.Data;

var builder = WebApplication.CreateBuilder(args);

// -----------------------------
// 1. Registrar servicios
// -----------------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar EF Core
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Habilitar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// -----------------------------
// 2. Configurar pipeline
// -----------------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty;
    });
}


// CORS DEBE IR ANTES DE AUTH Y ANTES DE MAPCONTROLLERS
app.UseCors("AllowFrontend");

app.UseAuthorization();

// Finalmente mapear los controladores
app.MapControllers();

app.Run();
