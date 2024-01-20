using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Web_API_Clinica.DTOs.PacientesAcciones;
using Web_API_Clinica.Models;
using Web_API_Clinica.Validators;

var builder = WebApplication.CreateBuilder(args);

// Entity Framework
builder.Services.AddDbContext<ClinicaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ClinicConnection"));
});
// Validators
builder.Services.AddScoped<IValidator<PacienteInsertDto>, PacienteInsertValidator>();

// Add services to the container.

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

// Especialidades, medicos, pacientes, turnos, obras sociales y facturas

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
