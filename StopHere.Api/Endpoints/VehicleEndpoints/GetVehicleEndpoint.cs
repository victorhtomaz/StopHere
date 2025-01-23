using StopHere.Api.Interfaces;
using StopHere.Core.Dtos.Requests.VehicleRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Handlers;

namespace StopHere.Api.Endpoints.VehicleEndpoints;

public class GetVehicleEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{licensePlate}", HandleAsync)
            .WithName("Vehicle: Listar veiculo")
            .WithSummary("Lista um veiculo pela placa")
            .Produces<Response<Vehicle?>>();

    public static async Task<IResult> HandleAsync(string licensePlate,
        IVehicleHandler handler)
    {
        var request = new GetVehicleRequest
        {
            LicensePlateValue = licensePlate
        };

        var result = await handler.GetAsync(request);
        return result.IsSuccess ?
            TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}
