using ElectricityPriceWebApi.Models;
using ElectricityPriceWebApi.NordPool;
using ElectricityPriceWebApi.Repositories;
using ElectricityPriceWebApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IElectricityPriceService, ElectricityPriceService>();
builder.Services.AddScoped<IElectricityPriceRepository, ElectricityPriceRepository>();
builder.Services.AddScoped<INordPoolClient, NordPoolClient>();

builder.Services.AddHttpClient();

builder.Services.AddControllers();
builder.Services.AddDbContext<ElectricityPriceContext>(x =>
    x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
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
