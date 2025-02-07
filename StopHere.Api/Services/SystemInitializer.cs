using Microsoft.AspNetCore.Identity;
using StopHere.Api.Entities;

namespace StopHere.Api.Services;

public class SystemInitializer
{
    public static async Task SeedRolesAsync(IServiceProvider service)
    {
        var roleManager = service.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        var roles = ApiConfiguration.Roles.Values.ToList();

        foreach (var roleName in roles)
        {
            bool exist = await roleManager.RoleExistsAsync(roleName);
            if (!exist)
            {
                var role = new IdentityRole<Guid>(roleName);
                await roleManager.CreateAsync(role);
            }
        }
    }

    public static async Task SeedAdmUserAsync(IServiceProvider service)
    {
        var userManager = service.GetRequiredService<UserManager<User>>();

        var roles = ApiConfiguration.Roles.Values.ToList();

        var admUser = new User
        {
            UserName = "Administrador",
            Email = "admin@stophere.com",
        };
        var password = "Senha123!";

        var user = await userManager.FindByNameAsync(admUser.UserName);
        if (user is null)
        {
            await userManager.CreateAsync(admUser, password);
            await userManager.AddToRolesAsync(admUser, roles);
        }
    }
}