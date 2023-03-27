using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EtudePop.Data;
using EtudePop.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EtudePopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EtudePopContext") ?? throw new InvalidOperationException("Connection string 'EtudePopContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
