using Microsoft.AspNetCore.Mvc;
using StopHere.Api.Interfaces;
using StopHere.Core.Dtos.Requests.VehicleRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Handlers;

namespace StopHere.Api.Endpoints.VehicleEndpoints;

public class DeleteListVehicleEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/list", HandleAsync)
            .WithName("Vehicle: Deletar lista")
            .WithSummary("Deleta uma lista de veiculos")
            .RequireAuthorization("admin")
            .Produces<Response<Vehicle?>>();

    public static async Task<IResult> HandleAsync([FromBody] DeleteVehiclesRequest request,
        IVehicleHandler handler)
    {
        var result = await handler.DeleteListAsync(request);
        return result.IsSuccess ?
            TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}
