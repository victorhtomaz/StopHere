using StopHere.Api.Interfaces;
using StopHere.Core.Dtos.Requests.ParkingPlaceRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Handlers;

namespace StopHere.Api.Endpoints.ParkingPlaceEndpoints;

public class DeleteParkingPlaceEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/", HandleAsync)
            .WithName("ParkingPlace: Deletar uma vaga")
            .WithSummary("Deleta uma vaga")
            .Produces<Response<ParkingPlace?>>();

    public static async Task<IResult> HandleAsync(int parkingPlaceNumber,
        IParkingPlaceHandler handler)
    {
        var request = new DeleteParkingPlaceRequest
        {
            Number = parkingPlaceNumber
        };

        var result = await handler.DeleteAsync(request);
        return result.IsSuccess ?
            TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}
