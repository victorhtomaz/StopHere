using StopHere.Api.Common.Api.Interfaces;
using StopHere.Core.Dtos.Requests.VehicleRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Handlers;

namespace StopHere.Api.Endpoints.VehicleEndpoints;

public class ChangeVehicleEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/", HandleAsync)
            .WithName("Vehicle: Atualizar dados")
            .WithSummary("Atualiza os dados de um veiculo")
            .Produces<Response<Vehicle?>>();

    public static async Task<IResult> HandleAsync(ChangeVehicleRequest request,
        IVehicleHandler handler)
    {
        var result = await handler.ChangeAsync(request);
        return result.IsSuccess ?
            TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}
