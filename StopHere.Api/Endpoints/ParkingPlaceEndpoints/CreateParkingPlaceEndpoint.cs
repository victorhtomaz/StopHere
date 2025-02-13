using Microsoft.AspNetCore.Mvc;
using StopHere.Api.Common.Api.Interfaces;
using StopHere.Core.Dtos.Requests.ParkingPlaceRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Handlers;

namespace StopHere.Api.Endpoints.ParkingPlaceEndpoints;

public class CreateParkingPlaceEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("ParkingPlace: Criar uma vaga")
            .WithSummary("Cria uma vaga")
            .Produces<Response<ParkingPlace?>>();
    
    public static async Task<IResult> HandleAsync([FromBody] CreateParkingPlaceRequest request, 
        IParkingPlaceHandler handler)
    {
        var result = await handler.CreateAsync(request);
        return result.IsSuccess ? 
            TypedResults.Created($"{result.Data?.Number}", result) : TypedResults.BadRequest(result);
    }
}
