using StopHere.Api.Endpoints.ClientEndpoints;
using StopHere.Api.Endpoints.ParkingPlaceEndpoints;
using StopHere.Api.Endpoints.VehicleEndpoints;
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
            .MapEndpoint<CreateParkingPlaceEndpoint>()
            .MapEndpoint<DeleteParkingPlaceEndpoint>()
            .MapEndpoint<GetParkingPlaceEndpoint>();

        endpoint.MapGroup("v1/vehicle")
            .WithTags("Vehicles")
            .MapEndpoint<ChangeVehicleEndpoint>()
            .MapEndpoint<CreateVehicleEndpoint>()
            .MapEndpoint<DeleteListVehicleEndpoint>()
            .MapEndpoint<GetVehicleEndpoint>();

        endpoint.MapGroup("v1/client")
            .WithTags("Clients")
            .MapEndpoint<ChangeClientEndpoint>()
            .MapEndpoint<CreateClientEndpoint>()
            .MapEndpoint<DeleteListClientEndpoint>()
            .MapEndpoint<GetByPhoneNumberClientEndpoint>()
            .MapEndpoint<GetListClientEndpoint>()
            .MapEndpoint<RenewServiceClientEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
