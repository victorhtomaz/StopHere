using StopHere.Api.Interfaces;
using StopHere.Core.Dtos.Requests.EntryExitRecordRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Handlers;

namespace StopHere.Api.Endpoints.EntryExitRecordEndpoints;

public class CreateEntryExitRecordEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("EntryExitRecord: Criar registro")
            .WithSummary("Cria um registro de entrada e saída")
            .Produces<Response<EntryExitRecord?>>();

    public static async Task<IResult> HandleAsync(CreateEntryExitRecordRequest request,
        IEntryExitRecordHandler handler)
    {
        var result = await handler.CreateAsync(request);
        return result.IsSuccess ?
            TypedResults.Created($"{result.Data?.Id}", result) : TypedResults.BadRequest(result);
    }
}
