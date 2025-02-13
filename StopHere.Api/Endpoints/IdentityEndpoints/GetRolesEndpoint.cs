using StopHere.Api.Common.Api.Interfaces;
using System.Security.Claims;

namespace StopHere.Api.Endpoints.IdentityEndpoints;

public class GetRolesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/roles", Handle)
            .WithName("Identity: Listar roles")
            .WithSummary("Lista as roles do usuário logado")
            .RequireAuthorization("funcionario");

    public static IResult Handle(ClaimsPrincipal user)
    {
        if (user.Identity is null || !user.Identity.IsAuthenticated)
            return Results.Unauthorized();
        
        var identity = (ClaimsIdentity) user.Identity;

        var roles = identity.FindAll(identity.RoleClaimType)
                .Select(c => new
                {
                    c.Issuer,
                    c.OriginalIssuer,
                    c.Type,
                    c.Value,
                    c.ValueType
                });

        return TypedResults.Json(roles);
    }
}
