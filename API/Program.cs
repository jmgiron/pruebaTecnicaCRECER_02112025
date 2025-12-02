
using Incidencias.Application.Interfaces;
using Incidencias.Application.Services;
using Incidencias.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IIncidenciaService, IncidenciaService>();
builder.Services.AddScoped<IIncidenciaRepository, IncidenciaRepository>();

builder.Configuration["ConnectionStrings:Oracle"]="User Id=PROCESOS;Password=PROCESOS;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.10.3.152)(PORT=6120)))(CONNECT_DATA=(SERVICE_NAME=DESA01)));";

var app=builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
