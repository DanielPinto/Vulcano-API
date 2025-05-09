using Vulcano.Application.Extensions;
using Vulcano.Application.Response;
using Vulcano.Application.UseCases.EquipmentUseCase;
using Vulcano.Domain.Interfaces;
using Vulcano.Infrastructure.Extensions;
using Vulcano.Infrastructure.Persistence;
using Vulcano.WebApi.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAppDbContext(builder.Configuration);


// Add services
builder.Services.AddSingleton<IEquipmentRepository, InMemoryEquipmentRepository >();
builder.Services.AddScoped<IApiResponseFormatter,ApiResponseFormatter>();
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
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

await app.RunAsync();