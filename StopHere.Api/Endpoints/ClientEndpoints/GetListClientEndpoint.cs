using Microsoft.AspNetCore.Mvc;
using StopHere.Api.Common.Api.Interfaces;
using StopHere.Core;
using StopHere.Core.Dtos.Requests.ClientRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Handlers;

namespace StopHere.Api.Endpoints.ClientEndpoints;

public class GetListClientEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Client: Lista uma lista")
            .WithSummary("Lista uma lista de clientes")
            .Produces<PagedResponse<IList<Client>>>();

    public static async Task<IResult> HandleAsync([FromQuery] int? pageNumber, [FromQuery] int? pageSize,
       IClientHandler handler)
    {
        var request = new GetListClientRequest
        {
            PageNumber = pageNumber ?? Configuration.DefaultPageNumber,
            PageSize = pageSize ?? Configuration.DefaultPageSize
        };

        var result = await handler.GetListAsync(request);
        return result.IsSuccess ?
            TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}
