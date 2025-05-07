using Vulcano.Application.Response;
using Vulcano.Application.UseCases.EquipmentUseCase;
using Vulcano.Application.Validators.EquipamentValidators;
using Vulcano.Domain.Interfaces;
using Vulcano.Infrastructure.Persistence;
using Vulcano.WebApi.Filters;
using Vulcano.Application.Extensions;
using FluentValidation;
using System.Diagnostics;
using FluentValidation.AspNetCore;
using Vulcano.Application.DTOs; // <- seu namespace da extensão AddValidators


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services
builder.Services.AddSingleton<IEquipmentRepository, InMemoryEquipmentRepository >();
builder.Services.AddScoped<IApiResponseFormatter,ApiResponseFormatter>();
builder.Services.AddScoped<EquipmentHandler>();
builder.Services.AddScoped<ValidateModelAttribute>();

builder.Services
    .AddControllers();



builder.Services.AddValidators();





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
//app.UseMiddleware<ExceptionMiddleware>();

await app.RunAsync();