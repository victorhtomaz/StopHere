using StopHere.Api.Services;

namespace StopHere.Api.Common.Api.Extensions;

public static class AppExtension
{
    public static void ConfigureDevEnvironment(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    public static async Task InitializeSystemData(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            await SystemInitializer.SeedRolesAsync(services);
            await SystemInitializer.SeedAdmUserAsync(services);
        }
    }

    public static void UseSecurity(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}
