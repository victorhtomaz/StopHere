using Microsoft.AspNetCore.Mvc;
using StopHere.Api.Interfaces;
using StopHere.Core.Dtos.Requests.EntryExitRecordRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Handlers;

namespace StopHere.Api.Endpoints.EntryExitRecordEndpoints;

public class DeleteListEntryExitRecordEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/", HandleAsync)
            .WithName("EntryExitRecord: Deletar lista")
            .WithSummary("Deleta uma lista de registros")
            .Produces<Response<EntryExitRecord?>>();

    public static async Task<IResult> HandleAsync([FromBody] DeleteEntryExitRecordsRequest request,
        IEntryExitRecordHandler handler)
    {
        var result = await handler.DeleteListAsync(request);
        return result.IsSuccess ?
            TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}
