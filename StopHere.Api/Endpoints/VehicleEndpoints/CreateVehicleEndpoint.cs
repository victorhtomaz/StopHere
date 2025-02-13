using StopHere.Api.Common.Api.Interfaces;
using StopHere.Core.Dtos.Requests.VehicleRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Handlers;

namespace StopHere.Api.Endpoints.VehicleEndpoints;

public class CreateVehicleEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Vehicle: Cria um veiculo")
            .WithSummary("Adiciona um veiculo na vaga")
            .Produces<Response<Vehicle?>>();

    public static async Task<IResult> HandleAsync(CreateVehicleRequest request,
        IVehicleHandler handler)
    {
        var result = await handler.CreateAsync(request);
        return result.IsSuccess ?
            TypedResults.Created($"{result.Data?.Id}", result) : TypedResults.BadRequest(result);
    }
}
