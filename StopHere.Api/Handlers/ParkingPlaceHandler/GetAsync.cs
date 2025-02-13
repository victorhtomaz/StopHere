using Microsoft.EntityFrameworkCore;
using StopHere.Core.Dtos.Requests.ParkingPlaceRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Enums;

namespace StopHere.Api.Handlers.ParkingPlaceHandler;

public partial class ParkingPlaceHandler
{
    public async Task<Response<ParkingPlace?>> GetAsync(GetParkingPlaceRequest request)
    {
        try
        {
            var parkingPlace = await context.ParkingPlaces.AsNoTracking().FirstOrDefaultAsync(p => p.Number == request.Number);
            if (parkingPlace is null)
                return new Response<ParkingPlace?>(null, EStatusCode.BadRequest, "Vaga não encontrada");

            return new Response<ParkingPlace?>(parkingPlace, EStatusCode.Ok);
        }
        catch
        {
            return new Response<ParkingPlace?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }
}
