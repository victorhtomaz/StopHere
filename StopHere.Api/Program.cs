using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StopHere.Api;
using StopHere.Api.Data;
using StopHere.Api.Endpoints;
using StopHere.Api.Entities;
using StopHere.Api.Handlers.ClientHandler;
using StopHere.Api.Handlers.EntryExitRecordHandler;
using StopHere.Api.Handlers.ParkingPlaceHandler;
using StopHere.Api.Handlers.VehicleHandler;
using StopHere.Api.Services;
using StopHere.Core.Handlers;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>
    (options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionstring, b => b.MigrationsAssembly("StopHere.Api")));

var roles = builder.Configuration.GetSection("Roles").GetChildren();
ApiConfiguration.Roles = roles
    .ToDictionary(role => role["Key"] ?? string.Empty, role => role["Name"] ?? string.Empty);

var teste = ApiConfiguration.Roles;

builder.Services.AddIdentityCore<User>().AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<AppDbContext>().AddApiEndpoints();

    builder.Services.AddScoped<IClientHandler, ClientHandler>();
builder.Services.AddScoped<IEntryExitRecordHandler, EntryExitRecordHandler>();
builder.Services.AddScoped<IParkingPlaceHandler, ParkingPlaceHandler>();
builder.Services.AddScoped<IVehicleHandler, VehicleHandler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();
builder.Services.AddAuthorization
    (options => 
    {
        options.AddPolicy("admin", policy => policy.RequireRole("Adminstrador"));
        options.AddPolicy("funcionario", policy => policy.RequireRole("Funcionário"));
    }
    );

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    await SystemInitializer.SeedRolesAsync(services);
    await SystemInitializer.SeedAdmUserAsync(services);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();