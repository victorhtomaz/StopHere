using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using StopHere.Api.Entities;
using StopHere.Api.Interfaces;

namespace StopHere.Api.Endpoints.IdentityEndpoints;

public class RegisterEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/register", HandleAsync)
            .WithName("Identity: Registrar")
            .WithSummary("Registra um novo funcionário")
            .RequireAuthorization("admin");
            
    public static async Task<IResult> HandleAsync(RegisterRequest request, UserManager<User> userManager)
    {
        var role = ApiConfiguration.Roles.FirstOrDefault(r => r.Key == "default");

        var user = new User
        {
            UserName = request.Email,
            Email = request.Email,
            NormalizedEmail = request.Email.ToUpper(),
        };

        var resultCreate = await userManager.CreateAsync(user, request.Password);
        if (resultCreate.Succeeded is false)
            Results.BadRequest();

        var resultAddToRole = await userManager.AddToRoleAsync(user, $"{role.Value}");
        if (resultAddToRole.Succeeded is false)
            Results.BadRequest();

        return Results.Ok();
    }
}
