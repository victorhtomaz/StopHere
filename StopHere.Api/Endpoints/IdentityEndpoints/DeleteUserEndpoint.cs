using Microsoft.AspNetCore.Identity;
using StopHere.Api.Common.Api.Interfaces;
using StopHere.Api.Entities;

namespace StopHere.Api.Endpoints.IdentityEndpoints;

public class DeleteUserEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{email}", HandleAsync)
            .WithName("Identity: Deletar usuario")
            .RequireAuthorization("admin");

    public static async Task<IResult> HandleAsync(string email, UserManager<User> userManager)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user is null)
            return Results.NotFound();

        var result = await userManager.DeleteAsync(user);
        return result.Succeeded ? Results.Ok() : Results.BadRequest();
    }
}