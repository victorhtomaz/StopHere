using StopHere.Api.Common.Api.Interfaces;
using StopHere.Core.Dtos.Requests.EntryExitRecordRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Handlers;

namespace StopHere.Api.Endpoints.EntryExitRecordEndpoints;

public class ChangeEntryExitRecordEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPatch("/{id:guid}", HandleAsync)
            .WithName("EntryExitRecord: Alterar saída")
            .WithSummary("Registra a saída do veículo")
            .Produces<Response<EntryExitRecord?>>();

    public static async Task<IResult> HandleAsync(Guid id,
        IEntryExitRecordHandler handler)
    {
        var request = new ChangeExitEntryExitRecordRequest
        {
            Id = id
        };

        var result = await handler.ChangeExitAsync(request);
        return result.IsSuccess ?
            TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}
