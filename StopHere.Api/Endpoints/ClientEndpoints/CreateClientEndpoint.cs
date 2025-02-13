using StopHere.Api.Common.Api.Interfaces;
using StopHere.Core.Dtos.Requests.ClientRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Handlers;

namespace StopHere.Api.Endpoints.ClientEndpoints;

public class CreateClientEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Client: Criar cliente")
            .WithSummary("Cria um cliente")
            .Produces<Response<Client?>>();

    public static async Task<IResult> HandleAsync(CreateClientRequest request,
        IClientHandler handler)
    {
        var result = await handler.CreateAsync(request);
        return result.IsSuccess ?
            TypedResults.Created($"{result.Data?.Id}", result) : TypedResults.BadRequest(result);
    }
}
