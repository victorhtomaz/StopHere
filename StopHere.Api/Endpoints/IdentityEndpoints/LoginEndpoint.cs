using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using StopHere.Api.Entities;
using StopHere.Api.Interfaces;

namespace StopHere.Api.Endpoints.IdentityEndpoints;

public class LoginEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/login", HandleAsync)
            .WithName("Identity: login")
            .AllowAnonymous();
    public static async Task<IResult> HandleAsync(LoginRequest request, UserManager<User> userManager,
        SignInManager<User> signInManager)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user is null)
            return Results.NotFound(); 

        await signInManager.SignInAsync(user, true);
        return Results.Ok();
    }
}
