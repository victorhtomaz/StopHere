using Microsoft.AspNetCore.Mvc;
using StopHere.Api.Interfaces;
using StopHere.Core.Dtos.Requests.EntryExitRecordRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Handlers;

namespace StopHere.Api.Endpoints.EntryExitRecordEndpoints;

public class GetListByPeriodEntryExitRecordEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("EntryExitRecord: Lista uma lista de registros")
            .WithSummary("Lista registros pelo período")
            .Produces<PagedResponse<IList<EntryExitRecord>>>();

    public static async Task<IResult> HandleAsync([FromQuery] int pageNumber, [FromQuery] int pageSize,
        [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate,
        IEntryExitRecordHandler handler)
    {
        var request = new GetListEntryExitRecordRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            StartDate = startDate,
            EndDate = endDate
        };

        var result = await handler.GetListByPeriodAsync(request);
        return result.IsSuccess ?
            TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}
