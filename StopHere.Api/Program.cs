using Microsoft.EntityFrameworkCore;
using StopHere.Api.Data;
using StopHere.Api.Endpoints;
using StopHere.Api.Handlers.ParkingPlaceHandler;
using StopHere.Core.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionstring, b => b.MigrationsAssembly("StopHere.Api")));

builder.Services.AddScoped<IParkingPlaceHandler, ParkingPlaceHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();