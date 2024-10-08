using Microsoft.EntityFrameworkCore;
using WeatherApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<WeatherDbContext>(
        options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyNewWeatherDB;"));
        //options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MonsterAspDbConnection;"));

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
