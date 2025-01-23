using StopHere.Api.Endpoints.ParkingPlaceEndpoints;
using StopHere.Api.Interfaces;

namespace StopHere.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoint = app.MapGroup("");

        endpoint.MapGroup("/")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "OK" });

        endpoint.MapGroup("v1/parking_place")
            .WithTags("Parking Place")
            .MapEndpoint<CreateEndpoint>()
            .MapEndpoint<DeleteEndpoint>()
            .MapEndpoint<GetEndpoint>();
    }

    public static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
