using Microsoft.AspNetCore.Mvc;
using StopHere.Api.Common.Api.Interfaces;
using StopHere.Core.Dtos.Requests.ClientRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Handlers;

namespace StopHere.Api.Endpoints.ClientEndpoints;

public class GetByPhoneNumberClientEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{phoneNumber}", HandleAsync)
            .WithName("Client: Lista um cliente")
            .WithSummary("Lista um cliente pelo número de telefone")
            .Produces<Response<Client?>>();

    public static async Task<IResult> HandleAsync(string phoneNumber,
        IClientHandler handler)
    {
        var request = new GetClientByPhoneNumberRequest
        {
            PhoneNumber = phoneNumber
        };

        var result = await handler.GetByPhoneNumberAsync(request);
        return result.IsSuccess ?
            TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}
