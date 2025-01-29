using Microsoft.EntityFrameworkCore;
using StopHere.Api.Data;
using StopHere.Api.Endpoints;
using StopHere.Api.Handlers.ClientHandler;
using StopHere.Api.Handlers.EntryExitRecordHandler;
using StopHere.Api.Handlers.ParkingPlaceHandler;
using StopHere.Api.Handlers.VehicleHandler;
using StopHere.Core.Handlers;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>
    (options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionstring, b => b.MigrationsAssembly("StopHere.Api")));

builder.Services.AddScoped<IClientHandler, ClientHandler>();
builder.Services.AddScoped<IEntryExitRecordHandler, EntryExitRecordHandler>();
builder.Services.AddScoped<IParkingPlaceHandler, ParkingPlaceHandler>();
builder.Services.AddScoped<IVehicleHandler, VehicleHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();