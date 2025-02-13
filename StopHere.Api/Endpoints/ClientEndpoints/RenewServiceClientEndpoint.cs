using Microsoft.AspNetCore.Mvc;
using StopHere.Api.Common.Api.Interfaces;
using StopHere.Core.Dtos.Requests.ClientRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Handlers;

namespace StopHere.Api.Endpoints.ClientEndpoints;

public class RenewServiceClientEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPatch("/{id:guid}", HandleAsync)
            .WithName("Client: Renovar serviço")
            .WithSummary("Renova o serviço de um cliente")
            .Produces<Response<Client?>>();

    public static async Task<IResult> HandleAsync(Guid id, [FromBody] RenewServiceClientRequest request,
        IClientHandler handler)
    {
        request.ClientId = id;

        var result = await handler.RenewServiceAsync(request);
        return result.IsSuccess ?
            TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}
