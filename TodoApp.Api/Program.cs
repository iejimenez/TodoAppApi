using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TodoApi.Infrastructure.Data;
using TodoApi.Infrastructure.Repositories;
using TodoApp.Application.Interfaces;
using TodoApp.Application.Services;
using TodoApp.Domain.Repositories;
using TodoApp.Api.Middleware;
using FluentValidation;
using TodoApp.Application.Validators;
using TodoApp.Application.DTOs;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<CreateTodoTaskDtoValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "TodoApp API", 
        Version = "v1",
        Description = "API para gestión de tareas",
        Contact = new OpenApiContact
        {
            Name = "Ivan Jimenez",
            Email = "iejimenez01@gmail.com"
        }
    });
});

builder.AddNpgsqlDbContext<ApplicationDbContext>("DefaultConnection");
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// Add Repositories
builder.Services.AddScoped<ITodoTaskRespository, TodoTaskRepoditory>();
builder.Services.AddScoped<ITodoTaskService, TodoTaskService>();

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDevServer",
        builder => builder
            .WithOrigins(
                "http://localhost:4200",
                "https://todoappclient-690260275830.northamerica-northeast2.run.app"
            )
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// Habilitar Swagger en todos los entornos
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApp API v1");
    c.RoutePrefix = "swagger";
});

// Importante: UseCors debe ir antes de UseAuthorization
app.UseCors("AllowAngularDevServer");

// Add global exception handling middleware
app.UseGlobalExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
