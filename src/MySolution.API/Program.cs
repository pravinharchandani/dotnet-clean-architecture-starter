using Microsoft.EntityFrameworkCore;
using MediatR;
using MySolution.Infrastructure.Data;
using MySolution.Core.Interfaces;
using MySolution.Infrastructure.Repositories;
using MySolution.Application.Requests;

var builder = WebApplication.CreateBuilder(args);

// DbContext - SQLite for local dev
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite("Data Source=dev.db"));

// Register repository implementations (infrastructure)
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

// Register MediatR handlers from Application assembly
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetCustomerQuery).Assembly));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
