using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StopHere.Api.Data;
using StopHere.Api.Entities;
using StopHere.Api.Handlers.ClientHandler;
using StopHere.Api.Handlers.EntryExitRecordHandler;
using StopHere.Api.Handlers.ParkingPlaceHandler;
using StopHere.Api.Handlers.VehicleHandler;
using StopHere.Core;
using StopHere.Core.Handlers;
using System.Text.Json.Serialization;

namespace StopHere.Api.Common.Api.Extensions;

public static class BuilderExtension
{
    public static void AddApiConfiguration(this WebApplicationBuilder builder)
    {
        ApiConfiguration.ConnectionString = builder.Configuration
            .GetConnectionString("DefaultConnection") ?? string.Empty;

        var roles = builder.Configuration.GetSection("Roles").GetChildren();
        ApiConfiguration.Roles = roles
            .ToDictionary(role => role["Key"] ?? string.Empty, role => role["Name"] ?? string.Empty);

        Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;

        Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
    }

    public static void AddConfigurationServices(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>
            (options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
    }

    public static void AddCrossOrigin(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors
            (options => options.AddPolicy
                (ApiConfiguration.CorsPolicyName, 
                policy => policy
                    .WithOrigins([Configuration.BackendUrl, Configuration.FrontendUrl])
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials())
                );
    }

    public static void AddDataContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>
            (options => options.UseSqlServer(ApiConfiguration.ConnectionString, b => b.MigrationsAssembly("StopHere.Api")));

        builder.Services.AddIdentityCore<User>()
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddApiEndpoints();
    }

    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }

    public static void AddSecurity(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();
        builder.Services.AddAuthorization
            (options =>
            {
                options.AddPolicy("admin", policy => policy.RequireRole("Administrador"));
                options.AddPolicy("funcionario", policy => policy.RequireRole("Funcionário"));
            }
            );
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IClientHandler, ClientHandler>();
        builder.Services.AddScoped<IEntryExitRecordHandler, EntryExitRecordHandler>();
        builder.Services.AddScoped<IParkingPlaceHandler, ParkingPlaceHandler>();
        builder.Services.AddScoped<IVehicleHandler, VehicleHandler>();
    }
}

