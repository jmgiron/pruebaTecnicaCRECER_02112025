using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Incidencias API",
        Version = "v1"
    });
});

var app = builder.Build();

// Enable swagger ALWAYS (even in Production)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Incidencias API v1");
    c.RoutePrefix = "swagger"; // Ruta: /swagger
});

// Routing
app.MapControllers();

app.Run();
