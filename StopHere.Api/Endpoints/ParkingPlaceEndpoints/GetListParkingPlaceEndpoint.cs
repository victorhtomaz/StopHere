using Microsoft.AspNetCore.Mvc;
using StopHere.Api.Interfaces;
using StopHere.Core.Dtos.Requests.ParkingPlaceRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Handlers;

namespace StopHere.Api.Endpoints.ParkingPlaceEndpoints;

public class GetListParkingPlaceEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("ParkingPlace: Listar vagas")
            .WithSummary("Lista uma lista de vagas")
            .Produces<PagedResponse<IList<ParkingPlace>>>();

    public static async Task<IResult> HandleAsync([FromQuery] int pageNumber, [FromQuery] int pageSize,
        IParkingPlaceHandler handler)
    {
        var request = new GetListParkingPlaceRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        var result = await handler.GetListAsync(request);
        return result.IsSuccess ?
            TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}
