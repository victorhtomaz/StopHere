using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using StopHere.Api.Common.Api.Interfaces;
using StopHere.Api.Entities;

namespace StopHere.Api.Endpoints.IdentityEndpoints;

public class ChangeUserCredentials : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPatch("/{email}", HandleAsync)
            .WithName("Identity: Mudar senha")
            .WithSummary("Altera o email e senha de um usuário")
            .RequireAuthorization("admin");

    public static async Task<IResult> HandleAsync(string email, InfoRequest request, 
        UserManager<User> userManager)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user is null)
            return Results.NotFound();

        if (request.NewEmail is not null)
        {
            var token = await userManager.GenerateChangeEmailTokenAsync(user, request.NewEmail);
            var resultEmail = await userManager.ChangeEmailAsync(user, request.NewEmail, token);
            await userManager.SetUserNameAsync(user, request.NewEmail);

            if (resultEmail.Succeeded is false)
                return Results.BadRequest();
        }

        if (request.NewPassword is not null)
        {
            var resultPassword = await userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);
            
            if (resultPassword.Succeeded is false)
                return Results.BadRequest();
        }

        return Results.Ok();
    }
}
