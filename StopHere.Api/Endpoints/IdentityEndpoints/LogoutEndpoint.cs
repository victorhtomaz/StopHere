using Microsoft.AspNetCore.Identity;
using StopHere.Api.Common.Api.Interfaces;
using StopHere.Api.Entities;

namespace StopHere.Api.Endpoints.IdentityEndpoints;

public class LogoutEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/logout", HandleAsync)
            .WithName("Identity: logout");

    public static async Task<IResult> HandleAsync(SignInManager<User> signInManager)
    {
        await signInManager.SignOutAsync();
        return Results.Ok();
    }
}
