using StopHere.Api.Interfaces;
using StopHere.Core.Dtos.Requests.ClientRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Handlers;

namespace StopHere.Api.Endpoints.ClientEndpoints;

public class ChangeClientEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id:guid}", HandleAsync)
            .WithName("Client: Atualizar dados")
            .WithSummary("Atualiza os dados de um cliente")
            .Produces<Response<Client?>>();

    public static async Task<IResult> HandleAsync(Guid id, ChangeClientRequest request,
        IClientHandler handler)
    {
        request.ClientId = id;

        var result = await handler.ChangeAsync(request);
        return result.IsSuccess ?
            TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}
