using StopHere.Api.Interfaces;
using StopHere.Core.Dtos.Requests.EntryExitRecordRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Handlers;

namespace StopHere.Api.Endpoints.EntryExitRecordEndpoints;

public class GetEntryExitRecordEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id:guid}", HandleAsync)
            .WithName("EntryExitRecord: Listar um registro")
            .WithSummary("Lista uma vaga pelo id do registro")
            .Produces<Response<EntryExitRecord?>>();

    public static async Task<IResult> HandleAsync(Guid id,
        IEntryExitRecordHandler handler)
    {
        var request = new GetEntryExitRecordRequest
        {
            Id = id
        };

        var result = await handler.GetAsync(request);
        return result.IsSuccess ?
            TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}
