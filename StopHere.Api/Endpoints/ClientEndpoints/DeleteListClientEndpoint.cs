using Microsoft.AspNetCore.Mvc;
using StopHere.Api.Interfaces;
using StopHere.Core.Dtos.Requests.ClientRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Handlers;

namespace StopHere.Api.Endpoints.ClientEndpoints;

public class DeleteListClientEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/", HandleAsync)
            .WithName("Client: Deletar lista")
            .WithSummary("Deleta uma lista de clientes")
            .Produces<Response<Client?>>();

    public static async Task<IResult> HandleAsync([FromBody] DeleteClientsRequest request,
        IClientHandler handler)
    {
        var result = await handler.DeleteListAsync(request);
        return result.IsSuccess ?
            TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}
