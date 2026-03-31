using Microsoft.EntityFrameworkCore;
using MyCleanApp.Application.Interfaces;
using MyCleanApp.Application.Services;
using MyCleanApp.Infrastructure;
using MyCleanApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Database - InMemory for development
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("MyCleanAppDb"));

// Dependency Injection - Clean Architecture
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();