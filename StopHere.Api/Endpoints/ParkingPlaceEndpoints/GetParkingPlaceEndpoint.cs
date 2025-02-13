using StopHere.Api.Common.Api.Interfaces;
using StopHere.Core.Dtos.Requests.ParkingPlaceRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Handlers;

namespace StopHere.Api.Endpoints.ParkingPlaceEndpoints;

public class GetParkingPlaceEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{parkingPlaceNumber:int}", HandleAsync)
            .WithName("ParkingPlace: Listar uma vaga")
            .WithSummary("Lista uma vaga pelo número da vaga")
            .Produces<Response<ParkingPlace?>>();

    public static async Task<IResult> HandleAsync(int parkingPlaceNumber,
        IParkingPlaceHandler handler)
    {
        var request = new GetParkingPlaceRequest
        {
            Number = parkingPlaceNumber
        };

        var result = await handler.GetAsync(request);
        return result.IsSuccess ?
            TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}
